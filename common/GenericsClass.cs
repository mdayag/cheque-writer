using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace common
{
    public class GenericsClass
    {
        static readonly object locker = new object();

        public GenericsClass()
        { }

        public T ConvertToModel<T>(T model, SqlDataReader reader) where T : new()
        {
            T newModel = new T();
            int ctr = 0;

            for (int i = 0; i < reader.VisibleFieldCount; i++)
            {
                ctr = 0;
                try
                {
                    newModel.GetType().GetProperty(reader.GetName(i)).SetValue(newModel, reader[i], null);
                }
                catch (Exception ex)
                {
                    ctr = ctr + 1;
                }
            }

            return newModel;
        }

        public void PassView<T>(T view, T viewParent)
        {

            PropertyInfo[] properties;

            //Common Fields
            foreach (Type tinterface in typeof(T).GetInterfaces())
            {
                properties = tinterface.GetProperties();
                PassView(view, viewParent, properties);
            }
            //Exclusive Fields
            properties = typeof(T).GetProperties();
            PassView(view, viewParent, properties);

        }

        public void PassView<T>(T view, T viewParent, PropertyInfo[] properties)
        {

            foreach (PropertyInfo item in properties)
            {
                if (item != null)
                {
                    try
                    {
                        view.GetType().GetProperty(item.Name).SetValue(view, viewParent.GetType().GetProperty(item.Name).GetValue(viewParent, null), null);
                    }
                    catch (Exception ex) { }
                }
            }
        }

        public void ConvertToList<T>(List<T> list, DataTable dt) where T : new()
        {
            int ctr = 0;

            lock (locker)
            {
                foreach (DataRow row in dt.Rows)
                {
                    T newModel = new T();
                    foreach (DataColumn column in dt.Columns)
                    {
                        try
                        {
                            newModel.GetType().GetProperty(column.ColumnName).SetValue(newModel, row[column], null);
                        }
                        catch (Exception ex)
                        { }
                    }
                    list.Add(newModel);
                }
            }
        }

        public bool IsValid<T, U>(T model, ref U view)
        {
            Validator validator = new Validator();
            List<ValidationResult> results = validator.ValidateAll<T>(model);
            string err = string.Empty;

            if (results.Count > 0)
            {
                foreach (ValidationResult item in results)
                {
                    err += ", " + item.Message;
                }

                view.GetType().GetProperty("_message").SetValue(view, "Cannot save data: " + err, null);

                return false;
            }
            return true;
        }

        public bool IsValid<T, U>(T model, U view)
        {
            Validator validator = new Validator();
            List<ValidationResult> results = validator.ValidateAll<T>(model);
            string err = string.Empty;

            if (results.Count > 0)
            {
                foreach (ValidationResult item in results)
                {
                    err += ", " + item.Message;
                }

                view.GetType().GetProperty("_message").SetValue(view, "Cannot save data: " + err, null);

                return false;
            }

            return true;
        }

        public void LoadForm<T, U>(T form, U parent)
            where T : Form
            where U : Form
        {
            try
            {
                if (Application.OpenForms.OfType<T>().Count() > 0)
                {
                    foreach (Form f in parent.MdiChildren)
                    {
                        if (f.Name.ToString() == form.Name)
                        {
                            f.Close();
                        }
                    }
                }
                form.MdiParent = parent;
                form.Show();
            }
            catch (Exception ex)
            { }
        }
    }
}

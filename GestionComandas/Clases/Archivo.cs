using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace GestionComandas
{
    class Archivo
    {
        private BinaryFormatter binaryFormatter;
        private Object objeto;

        public Archivo()
        {
            binaryFormatter = new BinaryFormatter();
        }

        public object Objeto { get => objeto; set => objeto = value; }

        public void Guardar(string pRuta, Object objeto)
        {
            try
            {
                FileStream fileStream = new FileStream(pRuta, FileMode.Create, FileAccess.Write);
                binaryFormatter.Serialize(fileStream, objeto);
                fileStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo almacenar el archivo (" + pRuta.ToUpper() + ") :" + ex.Message);
            }
        }

        public bool Leer(string pRuta)
        {
            if (File.Exists(pRuta))
            {
                try
                {
                    FileStream fileStream = new FileStream(pRuta, FileMode.Open, FileAccess.Read);
                    Objeto = binaryFormatter.Deserialize(fileStream);
                    fileStream.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo leer el archivo (" + pRuta.ToUpper() + ") :" + ex.Message);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("El archivo (" + pRuta.ToUpper() + ") no existe.");
                return false;
            }
        }
    }
}

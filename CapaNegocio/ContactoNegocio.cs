using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class ContactoNegocio
    {
        private ContactoDatos datos = new ContactoDatos();

        public DataTable Listar()
        {
            return datos.Listar();
        }

        public DataTable FiltrarPorGrupo(int idGrupo)
        {
            return datos.FiltrarPorGrupo(idGrupo);
        }

        public DataTable Buscar(string texto)
        {
            return datos.BuscarPorNombre(texto.Trim());
        }

        public void Guardar(Contacto contacto)
        {
            Validar(contacto);
            datos.Insertar(contacto.Nombre.Trim(), contacto.Telefono.Trim(),
                           contacto.Correo.Trim(), contacto.IdGrupo);
        }

        public void Modificar(Contacto contacto)
        {
            if (contacto.IdContacto <= 0)
            {
                throw new Exception("Seleccione un contacto de la lista para modificarlo.");
            }
            Validar(contacto);
            datos.Modificar(contacto.IdContacto, contacto.Nombre.Trim(), contacto.Telefono.Trim(),
                            contacto.Correo.Trim(), contacto.IdGrupo);
        }

        public void Eliminar(int idContacto)
        {
            if (idContacto <= 0)
            {
                throw new Exception("Seleccione un contacto de la lista para eliminarlo.");
            }
            datos.Eliminar(idContacto);
        }

        private void Validar(Contacto contacto)
        {
            if (string.IsNullOrWhiteSpace(contacto.Nombre))
            {
                throw new Exception("El nombre es obligatorio.");
            }

            if (contacto.IdGrupo <= 0)
            {
                throw new Exception("Seleccione un grupo.");
            }

            string telefono = "";
            if (contacto.Telefono != null)
            {
                telefono = contacto.Telefono.Trim();
            }

            if (telefono.Length != 10 || !SoloDigitos(telefono))
            {
                throw new Exception("El teléfono debe tener exactamente 10 dígitos numéricos.");
            }

            string correo = "";
            if (contacto.Correo != null)
            {
                correo = contacto.Correo.Trim();
            }

            if (!correo.Contains("@") || !correo.Contains("."))
            {
                throw new Exception("El correo debe contener @ y un punto.");
            }

            if (datos.ExisteTelefono(telefono, contacto.IdContacto))
            {
                throw new Exception("Ya existe un contacto con ese teléfono.");
            }
        }

        private bool SoloDigitos(string texto)
        {
            foreach (char c in texto)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
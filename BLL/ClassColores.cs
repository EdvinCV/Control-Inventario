using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELS;
using System.Collections;
using BLL.Repositorio;
using System.Xml;



namespace BLL
{
    public class ClassColores
    {
        ColoresEntities db;
        
        public IEnumerable MostrarClienteNIT(string nit)
        {
            db = new ColoresEntities();
            GenericRepository<Cliente> Rep = new GenericRepository<Cliente>(db);
            var r2 = from tp in Rep.ListarTodo()
                     where tp.NIT == nit
                     select new { Codigo_Cliente = tp.ClienteId, tp.Nombre, tp.Apellido, tp.DPI, tp.NIT, tp.Telefono };
            return r2.ToList();
        }

        public IEnumerable MostrarCategoria()
        {
            db = new ColoresEntities();
            GenericRepository<Categoria> Rep = new GenericRepository<Categoria>(db);
            var r2 = from tp in Rep.ListarTodo()
                     select new { Codigo_Categoria = tp.CategoriaId, Nombre = tp.Nombre };
            return r2.ToList();
        }

        public IEnumerable MostrarPermisos(int rol)
        {
            db = new ColoresEntities();
            GenericRepository<PermisoRol> PR = new GenericRepository<PermisoRol>(db);
            GenericRepository<Rol> R = new GenericRepository<Rol>(db);

            var r2 = from p in PR.ListarTodo()
                     join cat in R.ListarTodo()
                     on p.RolId equals cat.RolId
                     where cat.RolId == rol
                     select new {p.PermisoId};


            return r2.ToList();
        }

        public IEnumerable MostrarLogin(string user, string pass)
        {
            db = new ColoresEntities();
            GenericRepository<Usuario> U = new GenericRepository<Usuario>(db);

            var r2 = from l in U.ListarTodo()
                     where l.NombreUsuario == user
                     select new { l.NombreUsuario, l.password, l.RolId, l.UsuarioId};

            return r2.ToList();
        }

        public IEnumerable MostrarProductoE(int cod)
        {
            db = new ColoresEntities();
            GenericRepository<Producto> P = new GenericRepository<Producto>(db);
            GenericRepository<TipoProducto> TP = new GenericRepository<TipoProducto>(db);
            GenericRepository<Marca> MK = new GenericRepository<Marca>(db);
            GenericRepository<Medida> MD = new GenericRepository<Medida>(db);
            var r2 = from prod in P.ListarTodo()
                     join tipoP in TP.ListarTodo()
                     on prod.TipoProductoId equals tipoP.TipoProductoId
                     where prod.ProductoId == cod
                     join marc in MK.ListarTodo()
                     on tipoP.MarcaId equals marc.MarcaId
                     join medd in MD.ListarTodo()
                     on tipoP.MedidaId equals medd.MedidaId
                     where prod.Estado == true
                     select new { prod.ProductoId, tipoP.Nombre, tipoP.Precio, tipoP.Color, marc.NombreMarca, medd.NombreMedida, prod.TipoProductoId };
                     
            return r2.ToList();
        }

        public IEnumerable MostrarMarca()
        {
            db = new ColoresEntities();
            GenericRepository<Marca> Rep = new GenericRepository<Marca>(db);
            var r2 = from tp in Rep.ListarTodo()
                     select new { Codigo_Marca = tp.MarcaId, NombreMarca = tp.NombreMarca };
            return r2.ToList();
        }

        public IEnumerable MostrarCliente()
        {
            db = new ColoresEntities();
            GenericRepository<Cliente> Rep = new GenericRepository<Cliente>(db);
            var r2 = from tp in Rep.ListarTodo()
                     select new {Codigo_Cliente = tp.ClienteId, tp.Nombre, tp.Apellido, tp.DPI, tp.NIT, tp.Telefono};
            return r2.ToList();
        }

        public IEnumerable MostrarIdCliente(string n)
        {
            db = new ColoresEntities();
            GenericRepository<Cliente> Rep = new GenericRepository<Cliente>(db);
            var r2 = from tp in Rep.ListarTodo()
                     where tp.NIT == n
                     select new { tp.ClienteId };
             return r2.ToList();
        }

        public IEnumerable MostrarMedida()
        {
            db = new ColoresEntities();
            GenericRepository<Medida> Rep = new GenericRepository<Medida>(db);
            var r2 = from tp in Rep.ListarTodo()
                     select new { Codigo_Medida = tp.MedidaId, Medida = tp.NombreMedida };
            return r2.ToList();
        }

        public IEnumerable MostrarTipo()
        {
            db = new ColoresEntities();
            GenericRepository<TipoProducto> Rep = new GenericRepository<TipoProducto>(db);
            GenericRepository<Medida> Med = new GenericRepository<Medida>(db);
            var r2 = from tp in Rep.ListarTodo()
                     join med in Med.ListarTodo()
                     on tp.MedidaId equals med.MedidaId
                     select new { ProductoId = tp.TipoProductoId, tp.Nombre, tp.Precio, tp.Color, Nombre_Medida = med.NombreMedida};
            return r2.ToList();
        }

        public IEnumerable MostrarTipoFactura(int codCategoria)
        {
            db = new ColoresEntities();
            GenericRepository<TipoProducto> Rep = new GenericRepository<TipoProducto>(db);
            GenericRepository<Medida> Med = new GenericRepository<Medida>(db);
            GenericRepository<Marca> Mar = new GenericRepository<Marca>(db);
            var r2 = from tp in Rep.ListarTodo()
                     join med in Med.ListarTodo()
                     on tp.MedidaId equals med.MedidaId
                     join mark in Mar.ListarTodo()
                     on tp.MarcaId equals mark.MarcaId
                     where tp.CategoriaId == codCategoria
                     select new {tp.TipoProductoId, tp.Nombre, tp.Precio, tp.Color, med.NombreMedida, mark.NombreMarca};
                   
            return r2.ToList();

        }

        public IEnumerable Prods(int codTipo)
        {
            db = new ColoresEntities();
            GenericRepository<Producto> Rep = new GenericRepository<Producto>(db);
            var r2 = (from tp in Rep.ListarTodo()
                     orderby tp.ProductoId
                     where tp.TipoProductoId == codTipo && tp.Estado == true
                     select new { tp.ProductoId, tp.TipoProductoId, tp.Estado }).Take(1);
            return r2.ToList();
        }

        public IEnumerable MostrarProductoFactura(int cod)
        {
            db = new ColoresEntities();
            GenericRepository<Producto> P = new GenericRepository<Producto>(db);
            GenericRepository<TipoProducto> TP = new GenericRepository<TipoProducto>(db);
            GenericRepository<DetalleFactura> DF = new GenericRepository<DetalleFactura>(db);
            GenericRepository<Factura> F = new GenericRepository<Factura>(db);
            var r2 = from prod in P.ListarTodo()
                     join tipoP in TP.ListarTodo()
                     on prod.TipoProductoId equals tipoP.TipoProductoId
                     join detalle in DF.ListarTodo()
                     on prod.ProductoId equals detalle.ProductoId
                     join factura in F.ListarTodo()
                     on detalle.FacturaId equals factura.FacturaId
                     where factura.FacturaId == cod
                     select new { prod.ProductoId, tipoP.Nombre, tipoP.Precio, tipoP.Color, tipoP.TipoProductoId };
            return r2.ToList();
        }

        public string NuevaMedida(string nombreMedida)
        {
            string respuesta = "";
            Medida ob = new Medida();
            try
            {
                db = new ColoresEntities();
                GenericRepository<Medida> Rep = new GenericRepository<Medida>(db);
                ob.NombreMedida = nombreMedida;
                Rep.Agregar(ob);
                respuesta = "Medida agregada con éxito";
            }
            catch(Exception error)
            {
                respuesta = "Error al grabar" + error.Message;
            }
            return respuesta;
        }

        public string NuevaMarca(string nombreMarca)
        {
            string respuesta = "";
            Marca ob = new Marca();
            try
            {
                db = new ColoresEntities();
                GenericRepository<Marca> Rep = new GenericRepository<Marca>(db);
                ob.NombreMarca = nombreMarca;
                Rep.Agregar(ob);
                respuesta = "Marca agregada con éxito";
            }
            catch(Exception error)
            {
                respuesta = "Error al grabar" + error.Message;
            }
            return respuesta;
        }


        public string IngresarProducto(int tipo)
        {
            string respuesta = "";
            Producto Prod = new Producto();
            try
            {
                db = new ColoresEntities();
                GenericRepository<Producto> Rep = new GenericRepository<Producto>(db);
                Prod.Estado = true;
                Prod.TipoProductoId = tipo;
                Rep.Agregar(Prod);
            }
            catch (Exception error)
            {
                respuesta = "Error al ingresar" + error.Message;
            }
            return respuesta;

        }
        public string NuevaCategoria(string nombreCat)
        {
            string respuesta = "";
            Categoria cat = new Categoria();
            try
            {
                db = new ColoresEntities();
                GenericRepository<Categoria> Rep = new GenericRepository<Categoria>(db);
                cat.Nombre = nombreCat;
                Rep.Agregar(cat);
                respuesta = "Categoría agregada con éxito";
            }
            catch(Exception error)
            {
                respuesta = "Error al grabar" + error.Message;
            }
            return respuesta;
        }

        public string NuevoCliente(string nombre, string apellido, string DPI, string NIT, string telefono)
        {
            string respuesta = "";
            Cliente c = new Cliente();
            try
            {
                db = new ColoresEntities();
                GenericRepository<Cliente> Rep = new GenericRepository<Cliente>(db);
                c.Nombre = nombre;
                c.Apellido = apellido;
                c.DPI = DPI;
                c.NIT = NIT;
                c.Telefono = telefono;
                Rep.Agregar(c);
                respuesta = "Cliente agregado correctamente";
            }
            catch (Exception error)
            {
                respuesta = "Error al grabar" + error.Message;
            }
            return respuesta;
        }

        public string NuevoTipoProducto(string nombre, int precio, string color, int med, int marca, int cat)
        {
            string respuesta = "";
            TipoProducto tipo = new TipoProducto();
            try
            {
                db = new ColoresEntities();
                GenericRepository<TipoProducto> Rep = new GenericRepository<TipoProducto>(db);
                tipo.Nombre = nombre;
                tipo.Precio = precio;
                tipo.Color = color;
                tipo.MedidaId = med;
                tipo.MarcaId = marca;
                tipo.CategoriaId = cat;
                Rep.Agregar(tipo);
                respuesta = "Tipo ingresado correctamente";
            }
            catch (Exception error)
            {
                respuesta = "Error al grabar" + error.Message;
            }
            return respuesta;

        }

        public string ActualizarMedida(Medida med)
        {
            string respuesta = "";
            try
            {
                db = new ColoresEntities();
                GenericRepository<Medida> Rep = new GenericRepository<Medida>(db);
                Rep.Actualizar(med);
                respuesta = "La medida ha sido actualizada correctamente";
            }
            catch(Exception error)
            {
                respuesta = "Error al grabar" + error.Message;
            }
            return respuesta;

        }

        public string ActualizarProd(Producto p)
        {
            string respuesta = "";
            try
            {
                db = new ColoresEntities();
                GenericRepository<Producto> Rep = new GenericRepository<Producto>(db);
                Rep.Actualizar(p);
                respuesta = "Productos Actualizados";
            }
            catch (Exception error)
            {
                respuesta = "Error al grabar" + error.Message;
            }
            return respuesta;
        }


        public string BorrarProducto(Producto prod)
        {
            string respuesta = "";
            try
            {
                db = new ColoresEntities();
                GenericRepository<Producto> Rep = new GenericRepository<Producto>(db);
                Rep.Actualizar(prod);
            }
            catch
            {

            }
            return respuesta;
        }
        public string ActualizarCategoria(Categoria Objeto)
        {
            string respuesta = "";
            try
            {
                db = new ColoresEntities();
                GenericRepository<Categoria> Rep = new GenericRepository<Categoria>(db);
                Rep.Actualizar(Objeto);
                respuesta = "La categoría ha sido actualizada correctamente";
            }
            catch (Exception error)
            {
                respuesta = "Error al actualizar categoria" + error.Message;
            }
            return respuesta;
        }

        public string ActualizarTipo(TipoProducto objeto)
        {
            string respuesta = "";
            try
            {
                db = new ColoresEntities();
                GenericRepository<TipoProducto> Rep = new GenericRepository<TipoProducto>(db);
                Rep.Actualizar(objeto);
                respuesta = "El tipo ha sido actualizado";
            }
            catch (Exception error)
            {
                respuesta = "Error al actualizar categoría" + error.Message;
            }
            return respuesta;
        }
        public string ActualizarMarca(Marca Ob)
        {
            string respuesta = "";
            try
            {
                db = new ColoresEntities();
                GenericRepository<Marca> Rep = new GenericRepository<Marca>(db);
                Rep.Actualizar(Ob);
                respuesta = "La marca ha sido actualizada correctamente";
            }
            catch (Exception error)
            {
                respuesta = "Error al actualizar marca" + error.Message;
            }
            return respuesta;
        }

        public string ActualizarCliente(Cliente Ob)
        {
            string respuesta = "";
            try
            {
                db = new ColoresEntities();
                GenericRepository<Cliente> Rep = new GenericRepository<Cliente>(db);
                Rep.Actualizar(Ob);
                respuesta = "El cliente ha sido actualizado correctamente";
            }
            catch (Exception error)
            {
                respuesta = "Error al actualizar cliente" + error.Message;
            }
            return respuesta;
        }
        
        

        public bool ExisteNit(string nit)
        {
            using (ColoresEntities db = new ColoresEntities())
            {
                return db.Cliente.Any(x => x.NIT == nit);
            }
        }

        public bool ExisteProd(int cod)
        {
            using (ColoresEntities db = new ColoresEntities())
            {
                return db.Producto.Any(x => x.ProductoId == cod);
            }
        }



        //Funcion crear detalles
        public string CrearFact(int codEmpleado, int codUsuario, StringBuilder xxml, int codPago)
        {
            XmlDocument documento = new XmlDocument();
            documento.LoadXml(xxml.ToString());
            db = new ColoresEntities();
            var info = db.sp_CrearFactura(codEmpleado, codUsuario, documento.InnerXml,codPago).FirstOrDefault<string>();
            return info;
        }

        //Funcion crear pago
        public string CrearP(int t, StringBuilder xxml, int metodoUsar)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xxml.ToString());
            db = new ColoresEntities();
            var info = db.CreaPago2(t, doc.InnerXml, metodoUsar).FirstOrDefault<string>();
            return info;
        }

        public IEnumerable Factura(int cod)
        {
            db = new ColoresEntities();
            var info = (from sp in db.AnularFactura(cod)
                        select sp).ToList();
            return info;
        }
        



    }

}

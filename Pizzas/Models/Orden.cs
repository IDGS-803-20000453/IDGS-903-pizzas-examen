using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pizzas.Models
{
    public class Orden
    {
        public string NombreCompleto { get; set; }
        public string DireccionC { get; set; }
        public string TelefonoC { get; set; }
        public string Fechacompra { get; set; }
        public string Tamanio { get; set; }
        public string Ingredientes { get; set; }
		public bool Ingredientes1 { get; set; }
		public bool Ingredientes2 { get; set; }
		public bool Ingredientes3 { get; set; }


		public string CantidadP { get; set; }
        public int pizzasOrdenadas = 0;
        public int Total { get; set; }
        public Orden[] arrayObj2 = null;
        public double Subtotal=0;


        public Array pizzas1 { get; set; }
        List<string> miLista = new List<string>();

        public Array PedirOrden(Orden or)
        {

            pizzasOrdenadas = pizzasOrdenadas + 1;
            int subT = 0;
            String tam = "";
          
          
        
            
          
           
            switch (or.Tamanio)
            {
                case "1":
                    Console.WriteLine("Seleccionaste la opción 1");
                    subT= Int16.Parse(or.CantidadP)* 40;
                    tam = "chica";
                    break;
                case "2":
                    subT = Int16.Parse(or.CantidadP) * 80;
                    tam = "mediana";
                    break;
                case "3":
                    Console.WriteLine("Seleccionaste la opción 3");
                    // Lógica para la opción 3
                    subT = Int16.Parse(or.CantidadP) * 120;
                    tam = "grande";
                    break;
                default:
                    Console.WriteLine("Opción inválida");
                    // Lógica para opciones diferentes a 1, 2 y 3
                    break;
            }
			/*
            if(or.Ingrediente==null)
            {
                Debug.WriteLine("ESS NULLO");

            }
            else
            {
                Array ingredientes = (or.Ingrediente).Split(',');
                for (int j = 0; j < Int16.Parse(or.CantidadP); j++)
                {
                    for (int i = 0; i < ingredientes.Length; i++)
                    {
                        subT = subT + 10;
                    }

                }
            }*/
			for (int j = 0; j < Int16.Parse(or.CantidadP); j++)
            {
				if (or.Ingredientes1)
				{
					subT += 10;
				}
				if (or.Ingredientes2)
				{
					subT += 10;
				}
				if (or.Ingredientes3)
				{
					subT += 10;
				}

			}
			





			GuardarArhcivoPizzas(or, tam,subT.ToString());
            GuardarArhcivoDatos(or);

            Array pizzas2=LeerArchivoPizzasOrdenadas();

            return pizzas2;
        }
        public void GuardarArhcivoPizzas(Orden or, string tamanio, string subtotal)
        {
            var ruta = HttpContext.Current.Server.MapPath("~/App_Data/pizzasOrdenadas.txt");
            /* if (File.Exists(ruta))
             {
                 Console.WriteLine("El archivo si existe.");
                 File.Delete(ruta);
             }*/
            var ing = "";

            var datos="";
            var ingredientes = "";
			if (or.Ingredientes1)
			{
                ingredientes += "JAMON ";
			}
			if (or.Ingredientes2)
			{
				ingredientes += "CHAMPIÑON ";
			}
			if (or.Ingredientes3)
			{
				ingredientes += "PIÑA ";
			}
			datos = tamanio.ToUpper() + "." + ingredientes + "." + or.CantidadP + "." + subtotal + Environment.NewLine;
			//if (or.Ingrediente == null)
			//{
			//    ing = "No hay";
			//    datos = tamanio.ToUpper() + "." + "No hay" + "." + or.CantidadP + "." + subtotal + Environment.NewLine;

			//}
			//else
			//{
			//    ing = or.Ingrediente;
			//    datos = tamanio.ToUpper() + "." + ing.ToUpper() + "." + or.CantidadP + "." + subtotal + Environment.NewLine;

			//}


			File.AppendAllText(ruta, datos);
            
        }

        public void GuardarArhcivoDatos(Orden or)
        {
            var ruta = HttpContext.Current.Server.MapPath("~/App_Data/pizzasDatos.txt");
            if (File.Exists(ruta))
            {
                Console.WriteLine("El archivo si existe.");
                File.Delete(ruta);
            }
            var datos = or.NombreCompleto+ Environment.NewLine+
                or.DireccionC + Environment.NewLine +
                or.TelefonoC + Environment.NewLine +
                or.Fechacompra + Environment.NewLine ;
           
            File.AppendAllText(ruta, datos);

        }

        public Array LeerArchivoPizzasOrdenadas()
        {
            string[] pizzas = null;
            string[] pizzasCom = null;
            var ruta = HttpContext.Current.Server.MapPath("~/App_Data/pizzasOrdenadas.txt");
            if (File.Exists(ruta))
            {
                pizzas = File.ReadAllLines(ruta);
            }
            Debug.WriteLine(pizzas);
            for(int i = 0; i< pizzas.Length; i++)
            {
                string pizza = pizzas[i];
                Debug.WriteLine("Pizza # " + i + ": " + pizza);

                pizzasCom= pizzas[i].Split('.');
                for(int j = 0; j < pizzasCom.Length; j++)
                {
                    Debug.WriteLine("Pizza2 # " + i + ": " + pizzasCom[j]);
                }
            }
            return pizzas;
        }

        public Array LeerArchivoPizzasDatos()
        {
            string[] datos = null;
            string[] pizzasCom = null;
            var ruta = HttpContext.Current.Server.MapPath("~/App_Data/pizzasDatos.txt");
            if (File.Exists(ruta))
            {
                datos = File.ReadAllLines(ruta);
            }
           
            for (int i = 0; i < datos.Length; i++)
            {
                string pizza = datos[i];
                Debug.WriteLine("Pizza # " + i + ": " + pizza);

                pizzasCom = datos[i].Split('.');
                for (int j = 0; j < pizzasCom.Length; j++)
                {
                    Debug.WriteLine("Pizza2 # " + i + ": " + pizzasCom[j]);
                }
            }
            return datos;
        }

        public Array mostrarDetalle()
        {
            Array pizzas = LeerArchivoPizzasOrdenadas();
            return pizzas;
        }

        public Array mostrarDetalleDatos()
        {
            Array datos = LeerArchivoPizzasDatos();

            return datos;
        }
        /*
        public void GuardarDetalleOrden(Orden or,Array pizzas)
        {
            string[] pizzasCom = null;
            var datos = "Cliente: " + or.NombreCompleto.ToUpper() + Environment.NewLine +
                        "Direccion: " + or.DireccionC.ToUpper() + Environment.NewLine +
                        "Telefono: " + or.TelefonoC.ToUpper() + " Fecha Compra: " + or.Fechacompra.ToUpper() + "||" + Environment.NewLine;
            for (int i = 0; i < pizzas.Length; i++)
            {
                string pizza = pizzas.GetValue(i).ToString();
                pizzasCom = pizza.Split('.');
                Debug.WriteLine("Pizza # " + i + ": " + pizza);

                for (int j = 0; j < pizzasCom.Length; j++)
                {
                    Debug.WriteLine("Pizza2 # " + j + ": " + pizzasCom[j]);
                }
            }

            //datos = datos+"Pizzas: "+ tamanio.ToUpper() + "," + or.Ingrediente.ToUpper() + "." + or.CantidadP + "." + subtotal + Environment.NewLine;
            var ruta = HttpContext.Current.Server.MapPath("~/App_Data/OrdenDetalle.txt");
            File.AppendAllText(ruta, datos);

        }*/
    


}
    
}
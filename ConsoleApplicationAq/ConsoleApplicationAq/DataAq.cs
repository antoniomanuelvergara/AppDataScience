using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationAq
{
    public class DataAq
    {

        public Dictionary<int, RowData> Datos { get; set; }   
        public Dictionary<int, RowData> Positivos { get; set; }      
        public Dictionary<int, RowData> Negativos { get; set; }



     public DataAq()
        {
            Datos = new Dictionary<int, RowData>();
            Positivos = new Dictionary<int, RowData>();
            Negativos = new Dictionary<int, RowData>();
        }

         public void Data1()
         {
           

            //fila 1
            RowData rd1 = new RowData();

            rd1.Class.Value = "Comestible";
            rd1.Attributes = new List<ConsoleApplicationAq.Attribute>() {
                new Attribute() { Name = "Laminas", Value = "Si", Cost = 2, State = 1 },
                new Attribute() { Name = "Forma", Value = "Plano", Cost = 1, State = 1 },
                new Attribute() { Name = "Color", Value = "Pardo", Cost = 1, State = 1 }
            };

            Positivos.Add(1, rd1);
            Datos.Add(1, rd1);


            //fila 2
            RowData rd2 = new RowData();
            rd2.Class.Value = "Venenosa";
            rd2.Attributes = new List<ConsoleApplicationAq.Attribute>() {
                new Attribute() { Name = "Laminas", Value = "No", Cost = 2, State = 1 },
                new Attribute() { Name = "Forma", Value = "Convexo", Cost = 1, State = 1 },
                new Attribute() { Name = "Color", Value = "Pardo", Cost = 1, State = 1 }
            };

            Negativos.Add(2, rd2);
            Datos.Add(2, rd2);
            //fila 3
            RowData rd3 = new RowData();
            rd3.Class.Value = "Venenosa";
            rd3.Attributes = new List<ConsoleApplicationAq.Attribute>() {
                new Attribute() { Name = "Laminas", Value = "Si", Cost = 2, State = 1 },
                new Attribute() { Name = "Forma", Value = "Convexo", Cost = 1, State = 1 },
                new Attribute() { Name = "Color", Value = "Pardo", Cost = 1, State = 1 }
            };

            Negativos.Add(3, rd3);
            Datos.Add(3, rd3);

            //fila4
            RowData rd4 = new RowData();
            rd4.Class.Value = "Comestible";
            rd4.Attributes = new List<ConsoleApplicationAq.Attribute>() {
                new Attribute() { Name = "Laminas", Value = "Si", Cost = 2, State = 1 },
                new Attribute() { Name = "Forma", Value = "Convexo", Cost = 1, State = 1 },
                new Attribute() { Name = "Color", Value = "Rojo", Cost = 1, State = 1 }
            };

            Positivos.Add(4, rd4);
            Datos.Add(4, rd4);

            //fila 5
            RowData rd5 = new RowData();
            rd5.Class.Value = "Comestible";
            rd5.Attributes = new List<ConsoleApplicationAq.Attribute>() {
                new Attribute() { Name = "Laminas", Value = "No", Cost = 2, State = 1 },
                new Attribute() { Name = "Forma", Value = "Plano", Cost = 1, State = 1 },
                new Attribute() { Name = "Color", Value = "Pardo", Cost = 1, State = 1 }
            };

            Positivos.Add(5, rd5);
            Datos.Add(5, rd5);
        }

        public void Data2()
        {
            //fila 1
            RowData rd1 = new RowData();

            rd1.Class.Value = "Pacifico";
            rd1.Attributes = new List<ConsoleApplicationAq.Attribute>() {
                new Attribute() { Name = "Armas", Value = "No", Cost = 2, State = 1 },
                new Attribute() { Name = "Ropajes", Value = "Tela", Cost = 1, State = 1 },
                new Attribute() { Name = "Color", Value = "Verde", Cost = 1, State = 1 },
                new Attribute() { Name = "Sexo", Value = "Hombre", Cost = 1, State = 1 }
            };

            Positivos.Add(1, rd1);
            Datos.Add(1, rd1);


            //fila 2
            RowData rd2 = new RowData();

            rd2.Class.Value = "Enemigo";
            rd2.Attributes = new List<ConsoleApplicationAq.Attribute>() {
                new Attribute() { Name = "Armas", Value = "No", Cost = 2, State = 1 },
                new Attribute() { Name = "Ropajes", Value = "Tela", Cost = 1, State = 1 },
                new Attribute() { Name = "Color", Value = "Verde", Cost = 1, State = 1 },
                new Attribute() { Name = "Sexo", Value = "Mujer", Cost = 1, State = 1 }
            };

            Negativos.Add(2, rd2);
            Datos.Add(2, rd2);


            //fila 3
            RowData rd3 = new RowData();

            rd3.Class.Value = "Enemigo";
            rd3.Attributes = new List<ConsoleApplicationAq.Attribute>() {
                new Attribute() { Name = "Armas", Value = "Si", Cost = 2, State = 1 },
                new Attribute() { Name = "Ropajes", Value = "Armadura", Cost = 1, State = 1 },
                new Attribute() { Name = "Color", Value = "Verde", Cost = 1, State = 1 },
                new Attribute() { Name = "Sexo", Value = "Mujer", Cost = 1, State = 1 }
            };

            Negativos.Add(3, rd3);
            Datos.Add(3, rd3);

            //fila 4
            RowData rd4 = new RowData();

            rd4.Class.Value = "Pacifico";
            rd4.Attributes = new List<ConsoleApplicationAq.Attribute>() {
                new Attribute() { Name = "Armas", Value = "Si", Cost = 2, State = 1 },
                new Attribute() { Name = "Ropajes", Value = "Tela", Cost = 1, State = 1 },
                new Attribute() { Name = "Color", Value = "Rojo", Cost = 1, State = 1 },
                new Attribute() { Name = "Sexo", Value = "Hombre", Cost = 1, State = 1 }
            };

            Positivos.Add(4, rd4);
            Datos.Add(4, rd4);



            //fila 5
            RowData rd5 = new RowData();

            rd5.Class.Value = "Pacifico";
            rd5.Attributes = new List<ConsoleApplicationAq.Attribute>() {
                new Attribute() { Name = "Armas", Value = "Si", Cost = 2, State = 1 },
                new Attribute() { Name = "Ropajes", Value = "Tela", Cost = 1, State = 1 },
                new Attribute() { Name = "Color", Value = "Verde", Cost = 1, State = 1 },
                new Attribute() { Name = "Sexo", Value = "Mujer", Cost = 1, State = 1 }
            };

            Positivos.Add(5, rd5);
            Datos.Add(5, rd5);


        }

    }
}

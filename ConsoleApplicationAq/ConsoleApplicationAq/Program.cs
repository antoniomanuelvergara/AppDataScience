using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationAq
{
    class Program
    {
        static void Main(string[] args)
        {

            //ejecutamos y le mandamos los datos.
            DataAq datos = new DataAq();
            //datos.Data1();
            datos.Data2();
           
            //Entrenamiento
            AqController aqC = new AqController(datos);
            Recubrimiento recubrimiento = aqC.Start();
            Console.WriteLine(recubrimiento.GetRecubrimento());

            //Lista que se envia al clasificador para clasificar, hay que obtenerla
            List<RowData> listaParaClasificar = new List<RowData>();
            //aqui tenemos que poner el ejemplo que queremos evaluar

            RowData rd = new RowData();
        
            rd.Attributes = new List<ConsoleApplicationAq.Attribute>() {
                new Attribute() { Name = "Armas", Value = "Si", Cost = 2, State = 1 },
                new Attribute() { Name = "Ropajes", Value = "Tela", Cost = 1, State = 1 },
                new Attribute() { Name = "Color", Value = "Verde", Cost = 1, State = 1 },
                new Attribute() { Name = "Sexo", Value = "Mujer", Cost = 1, State = 1 }
            };
            RowData rd1 = new RowData();
            rd1.Attributes = new List<ConsoleApplicationAq.Attribute>() {
                new Attribute() { Name = "Armas", Value = "Si", Cost = 2, State = 1 },
                new Attribute() { Name = "Ropajes", Value = "Armadura", Cost = 1, State = 1 },
                new Attribute() { Name = "Color", Value = "Verde", Cost = 1, State = 1 },
                new Attribute() { Name = "Sexo", Value = "Hombre", Cost = 1, State = 1 }
            };



            listaParaClasificar.Add(rd);
            listaParaClasificar.Add(rd1);

            //fin de ejemplos que queremos evaluar

            //Clasificador, nota: podriamos hacerlo todo en el controlador, en lugar de tener una clase para esto. 
            Classificator clasificador = new Classificator(recubrimiento, listaParaClasificar);

            

            List<RowData> listaClasificada = clasificador.ClassifyList();
            foreach(RowData row in listaClasificada)
            {
                Console.WriteLine(row.Class.Value);
            }

            Console.ReadKey();


        }
    }
}

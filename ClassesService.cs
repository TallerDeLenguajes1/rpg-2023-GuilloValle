

using System.Net;
using System.Text.Json;
using CrearPersonaje;

public class ClassesService
    {
        // ante la falla respuesta consistente 
        // si funciona bien te devuelve una lista de clases
        public static List<string> GetClassesNames()
        {
                List<string> classesNames = new();  
                var url = $"https://www.dnd5eapi.co/api/classes/";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                try
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            if (strReader == null) return new List<string>();
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                var salida  = objReader.ReadToEnd();
                                var classes = JsonSerializer.Deserialize<PlayerTypeGroup>(salida)?.Classes; //Pregunto si es vacio lo que trajo la api
                                classes?.ForEach(classes => classesNames.Add(classes.name));                 //Cargo la lista con los nombres que trajo la api
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    Console.WriteLine("Problemas de acceso a la API");
                    return new List<string>();
                }

                return classesNames;  
        }
    }
using System.Text.Json;
namespace CrearPersonaje;


public class PersonajesJson
{       
        public void MostrarDatos(Personaje P)
        {
            Console.WriteLine("--Datos Personaje--");
            Console.WriteLine("Nombre:" + P.Nombre);
            Console.WriteLine("Edad:" + P.Edad);
            Console.WriteLine("Tipo: " + P.Tipo);
            Console.WriteLine("Fecha de Nacimiento:" + P.FechaDenacimiento.ToShortDateString());
        }

        public void GuardarPersonaje(List<Personaje> Personajes, string fileName)
        {
            string json = JsonSerializer.Serialize(Personajes);
            File.WriteAllText(fileName, json);

            
        }

        public List<Personaje> LeerPesonajes(string fileName)
        {
            
            var jsonString = File.ReadAllText(fileName);
            List<Personaje> personajesDeserializados = JsonSerializer.Deserialize<List<Personaje>>(jsonString);
            return personajesDeserializados;
            /*foreach (Personaje personaje in personajesDeserializados)
            {
                MostrarDatos(personaje);
            }*/
        }

        public bool Existe(string fileName)
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                return !string.IsNullOrEmpty(json);
            }
            return false;

        }


}
using System.Text.Json.Serialization;

namespace CrearPersonaje
{
    public static class nombresYapodos
    {
        public static string[] nombres = {
            "Aragorn",
            "Gandalf",
            "Legolas",
            "Gimli",
            "Frodo",
            "Samwise",
            "Gollum",
            "Boromir",
            "Galadriel",
            "Arwen",
            "Eowyn",
            "Sauron",
            "Saruman",
            "Gothmog",
            "Witch-King",
            "Bilbo",
            "Thorin",
            "Balin",
            "Gloin",
            "Elrond",
            "Thranduil",
            "Beorn",
            "Bard",
            "Bofur",
            "Faramir",
            "Denethor",
            "Eomer",
            "Theoden",
            "Tom Bombadil"

            };

        public static string[] apodos = {
            "El Desterrado",
            "El Sabio",
            "El Veloz",
            "El Valiente",
            "El Astuto",
            "El Leal",
            "El Renegado",
            "El Templario",
            "El Cazador",
            "El Impredecible",
            "El Hechicero",
            "El Errante",
            "El Furtivo",
            "El Maldito",
            "El Justiciero",
            "El Errabundo",
            "El Despiadado",
            "El Errante",
            "El Lobo Solitario",
            "El Caballero Negro",
            "El Guerrero Sagrado",
            "El Centinela",
            "El Espectro",
            "El Bardo",
            "El Saqueador",
            "El Jinete",
            "El Arpía",
            "El Granuja",
            "El Caminante",
            "El Titán",
            "El Errante",
            "El Forastero"
            };

           public static string[] tiposDePersonajes = {
                "Guerrero",
                "Mago",
                "Arquero",
                "Bárbaro",
                "Clerigo",
                "Paladín",
                "Ladrón",
                "Monje",
                "Hechicero",
                "Nigromante",
                "Bardo",
                "Druida",
                "Asesino",
                "Ranger",
                "Brujo",
                "Ingeniero",
                "Sacerdote",
                "Caballero",
                "Ninja",
                "Infiltrado",
                "Artista Marcial",
                "Médico",
                "Mercenario",
                "Vagabundo",
                "Tirador",
                "Alquimista",
                "Explorador",
                "Espadachín",
                "Bruja",
                "Cazador",
                "Hechicera"
            };


    

    }

    public class PlayerType
    {
        public string name { get; set; }
    }

    public class PlayerTypeGroup
    {
        public int count { get; set; }
        [JsonPropertyName("results")]
        public List<PlayerType> Classes { get; set; }
    }

}
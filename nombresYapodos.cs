namespace CrearPersonaje
{
    public static class nombresYapodos
    {
        public static string[] nombres = {
            "Juan",
            "María",
            "Pedro",
            "Ana",
            "Luis",
            "Laura",
            "Carlos",
            "Sofía",
            "Diego",
            "Valentina"

            };

        public static string[] apodos = {
            "Lui",
            "Mar",
            "Pete",
            "Ani",
            "Jota",
            "Carli",
            "Sofi",
            "Dany",
            "Migue",
            "Luchi"
            };


    

    }

    public class PlayerClass
    {
        public string name { get; set; }
    }

    public class PlayerClassGroup
    {
        public int count { get; set; }
        public List<PlayerClass> Classes { get; set; }
    }

}
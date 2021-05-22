using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP5_EF
{
    public partial class ReadJSON : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var webClient = new WebClient())
            {
                // Representación STRING de nuestro JSON
                string rawJSON = webClient.DownloadString("https://pokeapi.co/api/v2/pokemon/");
                //Convertir el JSON string a una lista de objetos
                PokemonTypeList pokemonTypeList = JsonConvert.DeserializeObject<PokemonTypeList>(rawJSON);

                Console.WriteLine(pokemonTypeList.Pokemon.Count);

                //this.pok = pokemonTypeList[0];
            }

        }
    }
}
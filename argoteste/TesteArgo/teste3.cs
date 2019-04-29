using System.IO;
using System.Net;
using System.Text;
using testeArgo.TesteArgo.Models;


namespace TesteArgo
{
    public class teste3
    {
        ///www.omdbapi.com/
        const string ApiKey = "18693fd6";

        /// <summary>
        /// By Search
        /// www.omdbapi.com/?s=titulo&apikey=18693fd6
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public SearchFilme ListarFilmes(string filtro)
        {
            var baseUri = $"http://www.omdbapi.com/?s={filtro}&apikey=18693fd6";

            var request = WebRequest.Create(baseUri);
            request.Method = "GET";
            request.ContentType = "application/json";

            SearchFilme filme;
            try
            {
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var result = reader.ReadToEnd();

                    filme = JsonConvert.DeserializeObject<SearchFilme>(result);

                    reader.Close();
                    response.Close();
                }

    
            }
            catch (WebException e)
            {
                throw e;
            }

            return filme;
        }

        /// <summary>
        /// By ID or Title
        /// www.omdbapi.com/?i=tt0372784&apikey=18693fd6
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Filme ListarPorId(string id)
        {
            var baseUri = $"http://www.omdbapi.com/?i={id}&apikey=18693fd6";
            
            var request = WebRequest.Create(baseUri);
            request.Method = "GET";
            request.ContentType = "application/json";

            Filme filmes;
            try
            {
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var result = reader.ReadToEnd();

                    filmes = JsonConvert.DeserializeObject<Filme>(result);

                    reader.Close();
                    response.Close();
                }
            }
            catch (WebException e)
            {
                throw e;
            }

            return filmes;
        }
    }
}

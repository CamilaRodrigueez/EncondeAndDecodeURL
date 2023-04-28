
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace ConsolePruebaTecnica.Domain
{
    public class TonyUrl
    {
        #region Propiedades
        public string Url { get; set; }
        #endregion

        public TonyUrl(string longurl)
        {
            this.Url = longurl;
        }
        #region Metodos
        public string Deconde(string shorUrl)
        {
            string ans = string.Empty;
            string apitonydecoder = "http://longurl.eti.pw/u?u=";
       

            var request = WebRequest.Create(apitonydecoder + shorUrl);
            var res = request.GetResponse();
            using (var reader = new StreamReader(res.GetResponseStream()))
            {
                ans = reader.ReadToEnd();
            }
            if (!string.IsNullOrEmpty(ans))
            {

                string cadena = ans;
                int indice1 = cadena.IndexOf("target='_blank'>") + "target='_blank'>".Length;
                int indice2 = cadena.IndexOf("</a><br />");
                // Restamos los índices para saber cuantos caracteres tenemos que coger
                int caracteres = indice2 - indice1;
                // Finalmente hacemos un substring del primer índice, cogiendo el número de caracteres necesarios. 
                string cadena2 = cadena.Substring(indice1, caracteres);
                return cadena2;
            }
            return "No se codificó la url";
        }

        public string Enconde(string longUrl)
        {
            string tiny = string.Empty;
            string apitony = "http://tinyurl.com/api-create.php?url=";
            //tiny = HttpUtility.UrlEncode(longUrl);
            //tiny = WebUtility.UrlEncode(longUrl);

            var request = WebRequest.Create(apitony  + longUrl);
            var res = request.GetResponse();
            using (var reader = new StreamReader(res.GetResponseStream()))
            {
                tiny = reader.ReadToEnd();
            }
            if (!string.IsNullOrEmpty(tiny))
            {
                return tiny;
            }
            return "No se codificó la url";
        } 
        #endregion
    }
}

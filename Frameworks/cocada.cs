using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Frameworks
{
    public class cocada
    {
        public async void UploadArquivos(ICollection<IFormFile> arquivo)
        {
            if (!(arquivo == null || arquivo.Count == 0))
            {
             
                long tamanhoArquivo = arquivo.Sum(f => f.Length);
                // caminho completo do arquivo na localização temporária
                var caminhoArquivo = Path.GetTempFileName();

                foreach (var arq in arquivo)
                { 
                    //string pasta = "C:/Base/1/Galeria";
                    string nomeArquivo =   DateTime.Now.Second.ToString();
                    nomeArquivo += Path.GetExtension(arq.FileName);
                    
                    string caminhoDestinoArquivo = "C:/Base/" + "1" + "/galeria";
                    //copia o arquivo para o local de destino original
                    using (var stream = new FileStream(caminhoDestinoArquivo, FileMode.Create))
                    {
                        await arq.CopyToAsync(stream);
                    }
                }               
            }
        }
    }
}


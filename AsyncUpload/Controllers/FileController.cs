using AsyncUpload.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AsyncUpload.Controllers
{
    public class FileController : Controller
    {
        // Formatos de archivos comunes para imágenes, videos y audios
        private readonly string[] images = new string[] { "jpg", "jpeg", "gif", "png", "webp", "bmp" };
        private readonly string[] videos = new string[] { "avi", "gp3", "mov", "m4v", "mp4", "mpg", "mpeg", "webm", "ogv" };
        private readonly string[] audios = new string[] { "wav", "mp3", "ogg", "wma", "aac" };

        /// <summary>
        /// Devuelve la representación de una cantidad de bytes en la unidad más alta posible.
        /// Se utilizan las clases derivadas de Models.SizeUnit para esto.
        /// </summary>
        private string ParseSize(int value)
        {
            var b = new ByteUnit();
            b.Value = value;
            return b.Get();
        }

        /// <summary>
        /// Si el arreglo contiene el valor solicitado, devuelve el resultado indicado.
        /// </summary>
        private string InArray(string[] array, string value, string result)
        {
            return array.Contains(value)
                ? result
                : null;
        }

        /// <summary>
        /// Devuelve el tipo del archivo solicitado
        /// </summary>
        private string GetType(string fileName)
        {
            string ext = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();
            return
                InArray(images, ext, "Imagen") ??
                InArray(videos, ext, "Video") ??
                InArray(audios, ext, "Audio") ??
                "Archivo " + ext.ToUpper();
        }

        public JsonResult Upload()
        {
            try
            {
                // Request.Files tiene la colección de archivos subidos en la solicitud,
                // identificados por el atributo name del elemento input
                var file = Request.Files["file-input"];
                return Json(new
                {
                    name = file.FileName,
                    size = ParseSize(file.ContentLength),
                    type = GetType(file.FileName)
                });
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}
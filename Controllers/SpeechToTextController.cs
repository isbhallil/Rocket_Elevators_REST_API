using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace Rocket_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeechToTextController : ControllerBase
    {
        // GET: api/speechtotext
        [HttpGet("{locale}")]
        public async Task<SpeechRecognitionResult> GetInterventions(string locale)
        {
            // var audioInput = AudioConfig.FromStreamInput()
            using (var recognizer = new SpeechRecognizer(config))
            {
                var config = SpeechConfig.FromSubscription("4f2b9dd2f5cc43d69c013c96a0ccb30a", "westus");
                config.SpeechRecognitionLanguage = locale;
                var reader = new StreamReader(Request.Body);
                var audioInput = Microsoft.CognitiveServices.Speech.Audio.AudioConfig.FromStreamInput(reader);
                var body = await reader.ReadToEndAsync();

                // var body = await reader.ReadAsync();
                var result = await recognizer.RecognizeOnceAsync();
                return result;

            };
        }

        public AudioStreamReader(Stream stream){
            _reader = new BinaryReader(stream);
        }

        public override int Read(byte[] databuffer, uint size){

        }

        private BinaryReader _reader;
    }
}

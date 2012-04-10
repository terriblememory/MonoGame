using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Linq;

namespace Microsoft.Xna.Framework.Content
{
    internal class EffectReader : ContentTypeReader<Effect>
    {
        private static EffectPool effectpool;

        public EffectReader()
        {
        }
		static string [] supportedExtensions = new string[]  {".fxg"};
		
		public static string Normalize(string FileName)
		{
            return ContentTypeReader.Normalize(FileName, supportedExtensions);
		}
		
		private static string TryFindAnyCased(string search, string[] arr, params string[] extensions)
		{
			return arr.FirstOrDefault(s => extensions.Any(ext => s.ToLower() == (search.ToLower() + ext)));
		}
		
		private static bool Contains(string search, string[] arr)
		{
			return arr.Any(s => s == search);
		}

        protected internal override Effect Read(ContentReader input, Effect existingInstance)
        {
            int count = input.ReadInt32();
            
#if NOMOJO
            // We currently do not support effect files
            // when MojoShader is disabled!
            throw new NotImplementedException();
#else
            Effect effect = new Effect(input.GraphicsDevice,input.ReadBytes(count));
            effect.Name = input.AssetName;
            
            return effect;
#endif
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Media.Imaging;
using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Imaging.Interop;
using Microsoft.VisualStudio.Shell.Interop;

namespace MadsKristensen.EditorExtensions
{
    ///<summary>Variable Length Quantity (VLQ) Base 64 Serializer</summary>
    ///<remarks>Inspired by <see cref="https://github.com/mozilla/source-map"/></remarks>
    public static class ImageHelper
    {
        private static IVsImageService2 _imageService;

        static ImageHelper()
        {
            _imageService = WebEssentialsPackage.GetGlobalService(typeof(SVsImageService)) as IVsImageService2;
        }

        public static BitmapSource GetImage(ImageMoniker moniker)
        {
            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.Flags = (uint)_ImageAttributesFlags.IAF_RequiredFlags;
            imageAttributes.ImageType = (uint)_UIImageType.IT_Bitmap;
            imageAttributes.Format = (uint)_UIDataFormat.DF_WPF;
            imageAttributes.LogicalHeight = 16;
            imageAttributes.LogicalWidth = 16;
            imageAttributes.StructSize = Marshal.SizeOf(typeof(ImageAttributes));

            IVsUIObject result = _imageService.GetImage(moniker, imageAttributes);

            Object data;
            result.get_Data(out data);

            if (data == null)
                return null;

            return data as BitmapSource;
        }
    }
}
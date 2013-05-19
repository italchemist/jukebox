
namespace Jukebox.Extensions.Transmitters.Streaming {
	using System.IO;
	using System.ServiceModel.Web;

	/// <summary>Streaming service.</summary>
	public class StreamingService : IStreamingService {
		/// <summary>Gets the stream.</summary>
		/// <returns>Stream.</returns>
		public Stream GetStream() {
			if (WebOperationContext.Current != null)
				WebOperationContext.Current.OutgoingResponse.ContentType = "audio/mpeg";
			return null; // TODO: return stream.
		}
	}
}
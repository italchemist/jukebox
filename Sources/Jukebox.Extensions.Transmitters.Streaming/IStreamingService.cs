
namespace Jukebox.Extensions.Transmitters.Streaming {
	using System.IO;
	using System.ServiceModel;
	using System.ServiceModel.Web;

	/// <summary>Streaming service interface.</summary>
	[ServiceContract]
	public interface IStreamingService {
		/// <summary>Gets the stream.</summary>
		/// <returns>Stream.</returns>
		[OperationContract, WebGet(UriTemplate = "/stream.mp3")]
		Stream GetStream();
	}
}

namespace Jukebox.Extensions.Transmitters.Streaming {
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Description;

	/// <summary>Streaming service host.</summary>
	public class StreamingServiceHost {
		/// <summary>Initializes a new instance of the <see cref="StreamingServiceHost"/> class.</summary>
		/// <param name="uri">The URI.</param>
		public StreamingServiceHost(Uri uri) {
			_uri = uri;
		}

		/// <summary>Starts service.</summary>
		public void Run() {
			_host = new ServiceHost(typeof(StreamingService), _uri);
			_host.AddServiceEndpoint(
				typeof(IStreamingService),
				new WebHttpBinding {
					MaxReceivedMessageSize = long.MaxValue,
					MaxBufferSize = int.MaxValue,
					ReceiveTimeout = TimeSpan.FromDays(1),
					CloseTimeout = TimeSpan.FromDays(1),
					SendTimeout = TimeSpan.FromDays(1),
					OpenTimeout = TimeSpan.FromDays(1),
					TransferMode = TransferMode.Streamed
				},
				"").Behaviors.Add(new WebHttpBehavior());

			_host.Open();
		}

		/// <summary>Stops service.</summary>
		public void Stop() {
			_host.Close();
		}

		/// <summary>The host.</summary>
		private ServiceHost _host;

		/// <summary>The uri.</summary>
		private readonly Uri _uri;
	}
}

namespace Jukebox.Extensions.Interfaces.Web.ResponseModels {
	/// <summary>Operation response.</summary>
	class OperationResponse {
		/// <summary>Initializes a new instance of the <see cref="OperationResponse"/> class.</summary>
		/// <param name="isSucessful">if set to <c>true</c> is sucessful.</param>
		/// <param name="error">The error.</param>
		public OperationResponse(bool isSucessful, string error = "") {
			IsSuccessful = isSucessful;
			Error = error;
		}

		/// <summary>Gets a value indicating whether this operation is successful.</summary>
		public bool IsSuccessful { get; private set; }

		/// <summary>Gets or sets the error.</summary>
		public string Error { get; set; }
	}
}

using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Chat.V1.Service.Channel {

    public class MemberCreator : Creator<MemberResource> {
        public string serviceSid { get; }
        public string channelSid { get; }
        public string identity { get; }
        public string roleSid { get; set; }
    
        /// <summary>
        /// Construct a new MemberCreator
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <param name="identity"> The identity </param>
        /// <param name="roleSid"> The role_sid </param>
        public MemberCreator(string serviceSid, string channelSid, string identity, string roleSid=null) {
            this.serviceSid = serviceSid;
            this.identity = identity;
            this.roleSid = roleSid;
            this.channelSid = channelSid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created MemberResource </returns> 
        public override async Task<MemberResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.POST,
                Domains.CHAT,
                "/v1/Services/" + this.serviceSid + "/Channels/" + this.channelSid + "/Members"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("MemberResource creation failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return MemberResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created MemberResource </returns> 
        public override MemberResource Create(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.POST,
                Domains.CHAT,
                "/v1/Services/" + this.serviceSid + "/Channels/" + this.channelSid + "/Members"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("MemberResource creation failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return MemberResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request) {
            if (identity != null) {
                request.AddPostParam("Identity", identity);
            }
            
            if (roleSid != null) {
                request.AddPostParam("RoleSid", roleSid);
            }
        }
    }
}
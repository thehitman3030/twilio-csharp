using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Messaging.V1.Service 
{

    /// <summary>
    /// ShortCodeResource
    /// </summary>
    public class ShortCodeResource : Resource 
    {
        private static Request BuildCreateRequest(CreateShortCodeOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Messaging,
                "/v1/Services/" + options.PathServiceSid + "/ShortCodes",
                client.Region,
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="options"> Create ShortCode parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ShortCode </returns> 
        public static ShortCodeResource Create(CreateShortCodeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="options"> Create ShortCode parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ShortCode </returns> 
        public static async System.Threading.Tasks.Task<ShortCodeResource> CreateAsync(CreateShortCodeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="shortCodeSid"> The short_code_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ShortCode </returns> 
        public static ShortCodeResource Create(string pathServiceSid, string shortCodeSid, ITwilioRestClient client = null)
        {
            var options = new CreateShortCodeOptions(pathServiceSid, shortCodeSid);
            return Create(options, client);
        }

        #if !NET35
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="shortCodeSid"> The short_code_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ShortCode </returns> 
        public static async System.Threading.Tasks.Task<ShortCodeResource> CreateAsync(string pathServiceSid, string shortCodeSid, ITwilioRestClient client = null)
        {
            var options = new CreateShortCodeOptions(pathServiceSid, shortCodeSid);
            return await CreateAsync(options, client);
        }
        #endif

        private static Request BuildDeleteRequest(DeleteShortCodeOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Messaging,
                "/v1/Services/" + options.PathServiceSid + "/ShortCodes/" + options.PathSid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="options"> Delete ShortCode parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ShortCode </returns> 
        public static bool Delete(DeleteShortCodeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="options"> Delete ShortCode parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ShortCode </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteShortCodeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathSid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ShortCode </returns> 
        public static bool Delete(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteShortCodeOptions(pathServiceSid, pathSid);
            return Delete(options, client);
        }

        #if !NET35
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathSid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ShortCode </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteShortCodeOptions(pathServiceSid, pathSid);
            return await DeleteAsync(options, client);
        }
        #endif

        private static Request BuildReadRequest(ReadShortCodeOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Messaging,
                "/v1/Services/" + options.PathServiceSid + "/ShortCodes",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read ShortCode parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ShortCode </returns> 
        public static ResourceSet<ShortCodeResource> Read(ReadShortCodeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<ShortCodeResource>.FromJson("short_codes", response.Content);
            return new ResourceSet<ShortCodeResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read ShortCode parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ShortCode </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<ShortCodeResource>> ReadAsync(ReadShortCodeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<ShortCodeResource>.FromJson("short_codes", response.Content);
            return new ResourceSet<ShortCodeResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ShortCode </returns> 
        public static ResourceSet<ShortCodeResource> Read(string pathServiceSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadShortCodeOptions(pathServiceSid){PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ShortCode </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<ShortCodeResource>> ReadAsync(string pathServiceSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadShortCodeOptions(pathServiceSid){PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns> 
        public static Page<ShortCodeResource> NextPage(Page<ShortCodeResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Messaging,
                    client.Region
                )
            );

            var response = client.Request(request);
            return Page<ShortCodeResource>.FromJson("short_codes", response.Content);
        }

        private static Request BuildFetchRequest(FetchShortCodeOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Messaging,
                "/v1/Services/" + options.PathServiceSid + "/ShortCodes/" + options.PathSid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="options"> Fetch ShortCode parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ShortCode </returns> 
        public static ShortCodeResource Fetch(FetchShortCodeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="options"> Fetch ShortCode parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ShortCode </returns> 
        public static async System.Threading.Tasks.Task<ShortCodeResource> FetchAsync(FetchShortCodeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathSid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ShortCode </returns> 
        public static ShortCodeResource Fetch(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchShortCodeOptions(pathServiceSid, pathSid);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathSid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ShortCode </returns> 
        public static async System.Threading.Tasks.Task<ShortCodeResource> FetchAsync(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchShortCodeOptions(pathServiceSid, pathSid);
            return await FetchAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a ShortCodeResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ShortCodeResource object represented by the provided JSON </returns> 
        public static ShortCodeResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<ShortCodeResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// The sid
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// The account_sid
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The service_sid
        /// </summary>
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }
        /// <summary>
        /// The date_created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The date_updated
        /// </summary>
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        /// <summary>
        /// The short_code
        /// </summary>
        [JsonProperty("short_code")]
        public string ShortCode { get; private set; }
        /// <summary>
        /// The country_code
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; private set; }
        /// <summary>
        /// The capabilities
        /// </summary>
        [JsonProperty("capabilities")]
        public List<object> Capabilities { get; private set; }
        /// <summary>
        /// The url
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        private ShortCodeResource()
        {

        }
    }

}
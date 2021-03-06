﻿/*
 * Freshdesk.Schema.Ticket -- Freshdesk Ticket
 *
 * This source-code is part of the Freshdesk API for C# library by Rory Fewell (rozniak) of Oddmatics for Agile ICT for Education Ltd.:
 * <<https://oddmatics.uk>>
 * <<http://www.agileict.co.uk>>
 * 	
 * Copyright (C) 2017 Oddmatics
 * 	
 * Sharing, editing and general licence term information can be found inside of the "LICENSE.MD" file that should be located in the root of this project's directory structure.
 */

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Freshdesk.Schema
{
    /// <summary>
    /// Represents a Freshdesk ticket.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class Ticket
    {
        // TODO: Add attachments property

        /// <summary>
        /// Gets or sets the ID of the agent to whom the ticket has been assigned.
        /// </summary>
        [JsonProperty("responder_id")]
        public string AssignedAgentId { get; set; }


        /// <summary>
        /// Gets the ID of the company to which this ticket belongs.
        /// </summary>
        /// <remarks>
        /// Technically this property is not read-only if you have the Estate plan, however I have no way of testing the
        /// Multiple Companies feature.
        /// </remarks>
        [JsonProperty("company_id", DefaultValueHandling = DefaultValueHandling.Ignore,  NullValueHandling = NullValueHandling.Ignore)]
        public long CompanyId { get; private set; }
        

        /// <summary>
        /// Gets or sets the email address(es) added in the 'cc' field of the incoming ticket email.
        /// </summary>
        [JsonProperty("cc_emails", NullValueHandling = NullValueHandling.Ignore)]
        public string[] CopiedInRecipients { get; set; }
        
        
        /// <summary>
        /// Gets the email address(es) added while replying to a ticket.
        /// </summary>
        [JsonProperty("reply_cc_emails", NullValueHandling = NullValueHandling.Ignore)]
        public string[] CopiedInRecipientsOnReply { get; private set; }


        /// <summary>
        /// Gets this ticket's creation timestamp.
        /// </summary>
        [JsonProperty("created_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime CreatedAt { get; private set; }


        /// <summary>
        /// Gets the key-value pairs containing the names and values of custom fields.
        /// </summary>
        [JsonProperty("custom_fields", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> CustomFields { get; private set; }


        /// <summary>
        /// Gets the content of the ticket in plain-text.
        /// </summary>
        [JsonIgnore]
        [JsonProperty("description_text")]
        public string Description { get; private set; }

        /// <summary>
        /// Gets or sets the timestamp that denotes when the ticket is due to be resolved.
        /// </summary>
        [JsonProperty("due_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime DueTime { get; set; }

        /// <summary>
        /// Gets or sets the email address of the requester.
        /// </summary>
        /// <remarks>
        /// If no contact exists with this email address in Freshdesk, it will be added as a new contact.
        /// </remarks>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the ID of email config which is used for this ticket.
        /// </summary>
        [JsonProperty("email_config_id", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public long EmailConfigId { get; set; }

        /// <summary>
        /// Gets or sets the Facebook ID of the requester.
        /// </summary>
        /// <remarks>
        /// A contact should exist with this facebook_id in Freshdesk.
        /// </remarks>
        [JsonProperty("facebook_id")]
        public string FacebookId { get; set; }

        /// <summary>
        /// Gets or sets the timestamp that denotes when the first response is due.
        /// </summary>
        [JsonProperty("fr_due_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime FirstResponseDueTime { get; set; }

        /// <summary>
        /// Gets whether the ticket has been escalated as the result of first response time being breached.
        /// </summary>
        [JsonProperty("fr_escalated", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool FirstResponseEscalated { get; private set; }

        /// <summary>
        /// Gets the email address(es) added while forwarding a ticket.
        /// </summary>
        [JsonProperty("fwd_emails", NullValueHandling = NullValueHandling.Ignore)]
        public string[] ForwardeeEmails { get; private set; }

        /// <summary>
        /// Gets or sets the ID of the group to which the ticket has been assigned.
        /// </summary>
        [JsonProperty("group_id", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public long GroupId { get; set; }

        /// <summary>
        /// Gets or sets the HTML content of the ticket.
        /// </summary>
        [JsonProperty("description")]
        public string HtmlDescription { get; set; }

        /// <summary>
        /// Gets the unique ID of the ticket.
        /// </summary>
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long Id { get; private set; }

        /// <summary>
        /// Determines whether this ticket has been deleted.
        /// </summary>
        /// <remarks>
        /// Deleted tickets will not be displayed in any views except the "deleted" filter.
        /// </remarks>
        [JsonProperty("deleted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsDeleted { get; private set; }

        /// <summary>
        /// Gets whether the ticket has been escalated for any reason.
        /// </summary>
        [JsonProperty("is_escalated", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsEscalated { get; private set; }


        /// <summary>
        /// Gets or sets the phone number of the requester.
        /// </summary>
        /// <remarks>
        /// If no contact exists with this phone number in Freshdesk, it will be added as a new contact. If the phone number is set and the email address is not, then the name attribute is mandatory.
        /// </remarks>
        [JsonProperty("phone")]
        public string PhoneNumber { get; set; }


        /// <summary>
        /// Gets or sets the priority of the ticket.
        /// </summary>
        [JsonProperty("priority", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public TicketPriority Priority { get; set; }


        /// <summary>
        /// Gets or sets the ID of the product to which the ticket is associated.
        /// </summary>
        [JsonProperty("product_id", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public long ProductId { get; set; }


        /// <summary>
        /// Gets the email addresses to which the ticket was originally sent.
        /// </summary>
        [JsonProperty("to_emails", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Recipients { get; private set; }


        /// <summary>
        /// Gets or sets the user ID of the requester.
        /// </summary>
        [JsonProperty("requester_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long RequesterId { get; set; }


        /// <summary>
        /// Gets or sets the name of the requester.
        /// </summary>
        [JsonProperty("name")]
        public string RequesterName { get; set; }


        /// <summary>
        /// Gets or sets the channel through which the ticket was created.
        /// </summary>
        [JsonProperty("source", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public TicketSource Source { get; set; }


        /// <summary>
        /// Gets whether the ticket has been marked as spam.
        /// </summary>
        [JsonProperty("spam", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Spam { get; private set; }


        /// <summary>
        /// Gets or sets the status of the ticket.
        /// </summary>
        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Status { get; set; }


        /// <summary>
        /// Gets or sets the subject of the ticket.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }


        /// <summary>
        /// Gets or sets the tags that have been associated with the ticket.
        /// </summary>
        [JsonProperty("tags", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string[] Tags { get; set; }


        /// <summary>
        /// Gets or sets the Twitter handle of the requester.
        /// </summary>
        /// <remarks>
        /// If no contact exists with this handle in Freshdesk, it will be added as a new contact.
        /// </remarks>
        [JsonProperty("twitter_id")]
        public string TwitterId { get; set; }


        /// <summary>
        /// Gets or sets the issue category that describes the ticket.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }


        /// <summary>
        /// Gets the ticket's last updated timestamp.
        /// </summary>
        [JsonProperty("updated_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime UpdatedAt { get; private set; }

        
        /// <summary>
        /// The Freshdesk connection instance that was used to acquire this ticket.
        /// </summary>
        private FreshdeskConnection FreshdeskConnection { get; set; }

        /// <summary>
        /// The conversations of this ticket retrieved from JSON.
        /// </summary>
        [JsonProperty("conversations", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private Conversation[] JsonConversations { get; set; }


        /// <summary>
        /// Initializes a new instance of the Ticket class.
        /// </summary>
        public Ticket() {
            Status = 2;
            Priority = TicketPriority.Low;
        }

        /// <summary>
        /// Initializes a new instance of the Ticket class from JSON source data.
        /// </summary>
        /// <param name="json">The JSON to deserialize from.</param>
        /// <param name="fdConn">The Freshdesk connection used to acquire this ticket.</param>
        public Ticket(string json, FreshdeskConnection fdConn = null)
        {
            JsonConvert.PopulateObject(json, this);

            FreshdeskConnection = fdConn;
        }

        /// <summary>
        /// Initializes a new instance of the Ticket class from a JSON object.
        /// </summary>
        /// <param name="obj">The JSON object.</param>
        /// <param name="fdConn">The Freshdesk connection used to acquire this ticket.</param>
        public Ticket(JObject obj, FreshdeskConnection fdConn = null)
        {
            using (var jReader = obj.CreateReader())
            {
                JsonSerializer.CreateDefault().Populate(jReader, this);
            }

            FreshdeskConnection = fdConn;
        }

        /// <summary>
        /// Return ticket view link.
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public string GetViewLink(FreshdeskConnection connection = null)
        {
            var baseUri = connection == null ? FreshdeskConnection.ConnectionUri : connection.ConnectionUri;
            return FreshHttpsHelper.UriForPath(baseUri, $"helpdesk/tickets/{Id}").AbsoluteUri;
        }


        /// <summary>
        /// Retrieves the conversations of this ticket.
        /// </summary>
        /// <returns>The conversations of this ticket as a read-only IList&lt;Conversation&gt; conversation.</returns>
        public async Task<IList<Conversation>> GetConversations()
        {
            if (JsonConversations != null)
                return JsonConversations;

            if (FreshdeskConnection == null)
                throw new InvalidOperationException("Ticket.InitializeConversations: No Freshdesk connection has been provided for this ticket.");
            
            return await FreshdeskConnection.GetTicketConversations(Id);
        }
    }
}

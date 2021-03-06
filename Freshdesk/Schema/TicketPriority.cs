﻿/*
 * Freshdesk.Schema.TicketPriority -- Freshdesk Ticket Priority Enumeration
 *
 * This source-code is part of the Freshdesk API for C# library by Rory Fewell (rozniak) of Oddmatics for Agile ICT for Education Ltd.:
 * <<https://oddmatics.uk>>
 * <<http://www.agileict.co.uk>>
 * 	
 * Copyright (C) 2017 Oddmatics
 * 	
 * Sharing, editing and general licence term information can be found inside of the "LICENSE.MD" file that should be located in the root of this project's directory structure.
 */

namespace Freshdesk.Schema
{
    /// <summary>
    /// Specifies constants to determine the priority rating of a ticket.
    /// </summary>
    public enum TicketPriority
    {
        Low = 1,
        Medium = 2,
        High = 3,
        Urgent = 4
    }
}

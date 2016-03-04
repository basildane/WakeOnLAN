/*
 *   WakeOnLAN - Wake On LAN
 *    Copyright (C) 2004-2016 Aquila Technology, LLC. <webmaster@aquilatech.com>
 *
 *    This file is part of WakeOnLAN.
 *
 *    WakeOnLAN is free software: you can redistribute it and/or modify
 *    it under the terms of the GNU General Public License as published by
 *    the Free Software Foundation, either version 3 of the License, or
 *    (at your option) any later version.
 *
 *    WakeOnLAN is distributed in the hope that it will be useful,
 *    but WITHOUT ANY WARRANTY; without even the implied warranty of
 *    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *    GNU General Public License for more details.
 *
 *    You should have received a copy of the GNU General Public License
 *    along with WakeOnLAN.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Diagnostics;

namespace SetupHelpers
{
    class Program
    {
        /// <summary>
        /// This program is called by the installer to perform final setup before launching WOL.
        /// Creates the eventlog Event Source.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            const String eventSource = "WakeOnLAN";

            switch (args[0])
            {
                case "/install":
                    if (!EventLog.SourceExists(eventSource))
                        EventLog.CreateEventSource(eventSource, "Application");
                    break;

                case "/uninstall":
                    if (EventLog.SourceExists(eventSource))
                        EventLog.DeleteEventSource(eventSource);
                    break;
            }
        }
    }
}

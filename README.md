# HeartbeatSender

## What's it?

A tool that continuously sends an HTTP POST request to the specified URL after a configurable amount of time. Allowing server owner to get real-time(<30 seconds) status of their server. And get immediate notification if it's down.

## Guide

Register an account on betteruptime.com, create a heartbeat monitor(you can get a URL here), and create the status webpage. 

After that, start up the server with the plugin, and then just change the URL in the config.

That's it. Your server will now continuously send a heartbeat message to the specified URL after a configurable amount of time. And you will be able to view your server's uptime status via a link.

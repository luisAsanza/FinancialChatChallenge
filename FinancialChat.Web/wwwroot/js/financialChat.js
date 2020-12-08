/*
 * financialChat.js
 *
 * Creates and starts a connection. Adds to the submit button a handler that sends messages to the hub (SignalR Hub).
 * Adds to the connection object a handler that receives messages from the hub and adds them to the list.
 * Taken from Microsoft documentation: https://docs.microsoft.com/en-us/aspnet/core/tutorials/signalr?view=aspnetcore-5.0&tabs=visual-studio
 */

"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/financialChatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = "<strong>" + user + " says </strong>" + msg;
    var li = document.createElement("li");
    li.innerHTML = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
    RestrictMaxNumberOfMessages();
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("messageInput").value;
    if (message.length > 0) {
        connection.invoke("SendMessage", message).catch(function (err) {
            HandleErrorMessage(err.toString());
        });
        document.getElementById("messageInput").value = "";
    }
    event.preventDefault();
});
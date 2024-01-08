var connectionUserCount = new signalR.HubConnectionBuilder().withUrl("/hubs/userCount").build();

connectionUserCount.on("updateTotalViews", value => {
    var newCountSpan = document.getElementById("totalViewCounter");
    newCountSpan.innerText = value.toString();
});

connectionUserCount.on("updateTotalUsers", value => {
    var newCountSpan = document.getElementById("totalUserCounter");
    newCountSpan.innerText = value.toString();
});

function newWindowLoadedOnClient() {
    connectionUserCount.send("NewWindowLoaded");
}

function fulfilled() {
    newWindowLoadedOnClient();
}

function rejected() {

}

connectionUserCount.start().then(fulfilled, rejected);
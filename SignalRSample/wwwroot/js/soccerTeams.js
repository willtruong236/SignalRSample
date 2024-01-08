var connectionSoccerTeams = new signalR.HubConnectionBuilder().withUrl("/hubs/soccerTeams").build();

var muSpan = document.getElementById("MU");
var rmSpan = document.getElementById("RM");
var psgSpan = document.getElementById("PSG");

connectionSoccerTeams.on("updateVote", (mu, rm, psg) => {
    muSpan.innerText = mu.toString();
    rmSpan.innerText = rm.toString();
    psgSpan.innerText = psg.toString();
});

function fulfilled() {
    connectionSoccerTeams.invoke("GetVoteResult").then(voteCounter => {
        muSpan.innerText = voteCounter.mu.toString();
        rmSpan.innerText = voteCounter.rm.toString();
        psgSpan.innerText = voteCounter.psg.toString();
    });
}

function rejected() {

}

connectionSoccerTeams.start().then(fulfilled, rejected);
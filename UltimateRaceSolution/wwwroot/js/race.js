const connection = new signalR.HubConnectionBuilder()
.withUrl('/raceHub')
.withAutomaticReconnect()
.build();


connection.on('RaceUpdated', (score) => {
// update positions
document.getElementById('lastUpdated').innerText = new Date(score.lastUpdated).toLocaleTimeString();


setPos('bike', score.bikePosition);
setPos('tesla', score.teslaPosition);
setPos('chopper', score.chopperPosition);
setPos('sub', score.subPosition);
setPos('jeep', score.jeepPosition);
setPos('plane', score.planePosition);


if (score.winner) {
document.getElementById('winner').innerText = `WINNER: ${score.winner}`;
}
});


function setPos(id, value){
const max = 5000; // finish distance
const pct = Math.min(100, Math.round((value / max) * 100));
const bar = document.getElementById(id + 'Bar');
bar.style.width = pct + '%';
document.getElementById(id + 'Pos').innerText = Math.round(value) + ' km';
}


connection.start().then(()=>{
console.log('connected to raceHub');
}).catch(err => console.error(err.toString()));


//// start button
//const startBtn = document.getElementById('star
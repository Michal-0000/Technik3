const sqlite3 = require('sqlite3').verbose();

const db = new sqlite3.Database('./notatki.db', sqlite3.OPEN_READWRITE | sqlite3.OPEN_CREATE, (err) => {
    if(err){
        console.log("Problem z polaczeniem z bazą danych ", err.message);
    }else{
        console.log("Serwer bazy danych dziala poprawnie...");
    }
});

db.run(`CREATE TABLE IF NOT EXISTS notes(
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        title TEXT NOT NULL,
        content TEXT NOT NULL,
        image TEXT,
        datautworzenia TEXT DEFAULT(datetime('now','localtime'))
    )`);

module.exports = db;


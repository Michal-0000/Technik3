const express = require('express');
const multer = require('multer');
const cors = require('cors');
const path = require('path');
const db = require('./database');

const app = express()
app.use(cors())
app.use(express.json())
app.use('/assets/images', express.static(path.join(__dirname, 'public/asstes/')))

// konfiguracja multera do przesylania plikow
const storage = multer.diskStorage({
    destination: 'public/assets/images',
    filename: (req, file, cb) => {cb(null, Date.now() + path.extname(file.originalname))}
});

const upload = multer({storage : storage})


//endpoint - zapisywania notatki
app.post('/upload', upload.single('image'), (req, res) => {
    const {title, content} = req.body;
    const imageURL = req.file ? `/assets/images/${req.file.filename}` : null;

    db.run(`INSERT INTO notes (title, content, image) VALUES (?,?,?)`, [title, content, imageURL],
        function(err){
            if(err){
            return res.status(500).json({error: err.message});
            }
            res.json({id: this.lastID, imageURL});
        });
});


//endpoint - pobieranie wszystkich notatek z bazy
app.get('/notes', (req, res) => {
    db.all('SELECT * FROM notes', [], 
        function(err, rows){
            if(err){
                return res.status(500).json({error: err.message});
            }
            res.json(rows);
        });
});

//endpoint - usuwanie notatki z bazy
app.delete(`/notes/:id`, (req, res) => {
    const {id} = req.params;
    db.run(`DELETE FROM notes WHERE id = ?`, [id],
        function(err){
            if(err){
                return res.status(500).json({error: err.message});
            }
            res.json({message: "Usunieto rekord z bazy"});
        });
});

app.listen(3000, () => console.log("Serwer dziala na porcie 3000..."));
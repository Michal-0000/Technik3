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
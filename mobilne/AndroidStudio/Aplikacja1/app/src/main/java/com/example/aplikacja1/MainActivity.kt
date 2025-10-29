package com.example.aplikacja1

import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity

class MainActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)

        val poleTekstowe = findViewById<EditText>(R.id.poleTekstowe)
        val przycisk = findViewById<Button>(R.id.przycisk)
        val komunikat = findViewById<TextView>(R.id.Komunikat)

        przycisk.setOnClickListener {
            komunikat.text = poleTekstowe.text.toString()
        }
    }
}
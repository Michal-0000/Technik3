package com.example.aktywnosci1;

import static com.example.aktywnosci1.R.id.btnPowrot;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class Druga extends AppCompatActivity {
    EditText edit2;
    Button btn2;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.druga);

        edit2 = findViewById(R.id.edit2);
        btn2 = findViewById(R.id.btnPowrot);


        btn2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent();
                String imie = edit2.getText().toString();
                intent.putExtra("wynik", imie);
                setResult(1, intent);
                finish();
            }
        });
    }
}
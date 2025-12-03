package com.example.licznik;

import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

public class MainActivity extends AppCompatActivity {

    Button btnPolicz;
    TextView textView;
    EditText editText;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        btnPolicz = findViewById(R.id.btnLicz);
        textView = findViewById(R.id.textView);
        editText = findViewById(R.id.editText1);

        btnPolicz.setOnClickListener(view -> {
            String text = editText.getText().toString().trim();

            if(text.isEmpty()) {
                textView.setText("0");
                return;
            }

            var tab = text.split("\\s+");
            textView.setText(String.valueOf(tab.length));
        });
    }
}

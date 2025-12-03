package com.example.myapplication;

import android.content.ClipData;
import android.content.ClipDescription;
import android.content.ClipboardManager;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class MainActivity extends AppCompatActivity {

    Button btnSkopiuj, btnWklej;
    EditText editText1, editText2, editText3;
    private ClipboardManager clipboardManager;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        editText1 = findViewById(R.id.editText1);
        editText2 = findViewById(R.id.editText2);
        editText3 = findViewById(R.id.editText3);
        btnSkopiuj = findViewById(R.id.btnSkopiuj);
        btnWklej = findViewById(R.id.btnWklej);
        clipboardManager = (ClipboardManager) getSystemService(CLIPBOARD_SERVICE);

        btnSkopiuj.setOnClickListener(view -> {
            String textSkopiowany = editText1.getText().toString();
            if(!textSkopiowany.isEmpty()){
                ClipData clip = ClipData.newPlainText("text", textSkopiowany);
                clipboardManager.setPrimaryClip(clip);
                Toast.makeText(MainActivity.this, "Skopiowano do schowka", Toast.LENGTH_LONG).show();
            }else{
                Toast.makeText(MainActivity.this, "Brak tekstu", Toast.LENGTH_LONG).show();
            }
        });

        btnWklej.setOnClickListener(view -> {
            if(clipboardManager.hasPrimaryClip() && clipboardManager.getPrimaryClipDescription().hasMimeType(ClipDescription.MIMETYPE_TEXT_PLAIN)){
                ClipData.Item item = clipboardManager.getPrimaryClip().getItemAt(0);
                String doWklejenia = item.getText().toString();
                editText2.setText(doWklejenia);
                Toast.makeText(MainActivity.this, "Wklejono ze schowka", Toast.LENGTH_LONG).show();
            }else{
                Toast.makeText(MainActivity.this, "Nie ma nic w schowku", Toast.LENGTH_LONG).show();
            }//lekcja 15 zad 1,2
        });
    }
}
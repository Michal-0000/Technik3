package com.example.cwiczenie1;

import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.nio.charset.StandardCharsets;

//wpisac w okno nazwe kraju ktore chce wczytac i na githuba
public class MainActivity extends AppCompatActivity {

    private TextView populationText, areaText, densityText;
    private ImageView flagImage;

    private Country kraj;

    EditText searchText;
    Button increaseBtn, descreaseBtn, searchBtn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main);

        populationText = findViewById(R.id.populationText);
        areaText = findViewById(R.id.areaText);
        densityText = findViewById(R.id.densityText);
        flagImage = findViewById(R.id.flagImage);
        descreaseBtn = findViewById(R.id.decreaseBtn);
        increaseBtn = findViewById(R.id.increaseBtn);
        searchText = findViewById(R.id.searchText);
        searchBtn = findViewById(R.id.searchBtn);

        kraj = loadData("Polska");



        updateUI(kraj);

        increaseBtn.setOnClickListener(v -> {
            kraj.liczba_mieszkancow += 100000;
            updateUI(kraj);
        });

        descreaseBtn.setOnClickListener(v -> {
            kraj.liczba_mieszkancow = Math.max(0, kraj.liczba_mieszkancow - 100000);
            updateUI(kraj);
        });

        searchBtn.setOnClickListener(v -> {
            String s = searchText.getText().toString();
            if(s.isEmpty()){
                Toast.makeText(this, "Wypełnij pole wyszukiwania.", Toast.LENGTH_SHORT).show();
                return;
            }
            Country c = loadData(s);
            if(c == null){
                Toast.makeText(this, "Nie znaleziono danego kraju.", Toast.LENGTH_SHORT).show();
                return;
            }
            kraj = c;
            updateUI(kraj);
        });


    }

    private void updateUI(Country country){
        if(kraj == null) return;
        int resId = getResources().getIdentifier(kraj.flaga.replace(".png",""), "drawable", getPackageName());
        flagImage.setImageResource(resId);
        populationText.setText("Liczba mieszkańców: "+ country.liczba_mieszkancow / 1000  + " tys.");
        areaText.setText("Powierzchnia: "+ country.powierzchnia/1000 + "tys. km 2 ");
        double density = (double)country.liczba_mieszkancow / country.powierzchnia;
        densityText.setText("Gęstość zaludnienia: " + String.format("%.2f", density) + " os./km2");
    }

    private Country loadData(String searched){
        try{
            InputStream is = getResources().openRawResource(R.raw.panstwa);
            BufferedReader reader = new BufferedReader(new InputStreamReader(is, StandardCharsets.UTF_8));

            StringBuilder sb = new StringBuilder();
            String line;

            while((line = reader.readLine())!= null){
                sb.append(line);
            }

            JSONObject obj = new JSONObject(sb.toString());
            JSONArray arr = obj.getJSONArray("panstwa");

            // rozpakowanie JSON do country
            for(int i=0;i<arr.length(); i++){
                JSONObject country = arr.getJSONObject(i);
                if(searched.trim().equalsIgnoreCase(country.getString("kraj"))){
                    Country c = new Country();
                    c.kraj = country.getString("kraj");
                    c.liczba_mieszkancow = country.getInt("liczba_mieszkancow");
                    c.powierzchnia = country.getInt("powierzchnia");
                    c.flaga = country.getString("flaga");
                    return c;
                }
            }
        }catch (Exception ex){
            ex.printStackTrace();
        }
        return null;
    }
}
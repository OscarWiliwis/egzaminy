package com.example.myapplication;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class MainActivity extends AppCompatActivity {
    private int counter = 0; // Użycie "private" dla lepszej enkapsulacji

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // Ustawienia dla okienka z paskiem systemowym
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        // Inicjalizacja przycisków i tekstu
        Button buttonLike = findViewById(R.id.button4);
        Button buttonDislike = findViewById(R.id.button2);
        TextView txtLikes = findViewById(R.id.textView);

        // Obsługa kliknięcia przycisku "Polub"
        buttonLike.setOnClickListener(v -> {
            counter++;
            updateLikesText(txtLikes);
        });

        // Obsługa kliknięcia przycisku "Usuń"
        buttonDislike.setOnClickListener(v -> {
            if (counter > 0) counter--;
            updateLikesText(txtLikes);
        });
    }

    // Metoda do aktualizacji tekstu polubień
    private void updateLikesText(TextView txtLikes) {
        txtLikes.setText(counter + " polubień");
    }
}

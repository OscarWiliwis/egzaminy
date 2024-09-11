package com.example.myapplication;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import androidx.appcompat.app.AppCompatActivity;

public class MainActivity extends AppCompatActivity {
    private int counter = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // Inicjalizacja przycisków i tekstu
        Button buttonLike = findViewById(R.id.button4);
        Button buttonDislike = findViewById(R.id.button2);
        TextView txtLikes = findViewById(R.id.textView);

        // Obsługa kliknięcia przycisków
        buttonLike.setOnClickListener(v -> updateLikes(++counter, txtLikes));
        buttonDislike.setOnClickListener(v -> {
            if (counter > 0) updateLikes(--counter, txtLikes);
        });
    }

    // Metoda do aktualizacji tekstu polubień
    private void updateLikes(int currentCounter, TextView txtLikes) {
        txtLikes.setText(currentCounter + " polubień");
    }
}

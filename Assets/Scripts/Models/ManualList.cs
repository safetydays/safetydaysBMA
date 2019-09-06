using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualList : MonoBehaviour
{
    private string[] titles;
    private string[] texts;

    // Start is called before the first frame update
    void Start()
    {
        titles = new string[6];
        texts = new string[6];
        titles[0] = "Einleitung";
        texts[0] = "Die BMApp bringt Dir die Bedienung einer \nBrandmeldeanlage näher. \n \nDu kannst alleine im Einzelspielermodus \noder im Team trainieren. \n \nNimm Feuerwehrpläne und Laufkarten \nhinzu und Du kannst das Training noch \nrealistischer machen. \n \nMit der BMApp kannst Du sogar Trainings in \nechten Gebäuden machen, ohne die dortige \nBrandmeldeanlage auslösen zu müssen. \n \nIm Tutorial werden Dir die einzelnen \nBedienelemente vorgestellt. \n";
        titles[1] = "Tutorial";
        texts[1] = "Im Tutorial werden Dir Feuerwehranzeigetableau und Feuerwehrbedienfeld angezeigt. Tippe auf die einzelnen Bedienelemente und Du bekommst die Funktion erklärt.";
        titles[2] = "Teamtraining (1/2)";
        texts[2] = "Im Menü Simulation kannst Du ein \nTeamtraining starten. Im Teamtraining kann \nder Trainer Alarmmeldungen auf die Geräte \nder Übenden schicken. \n \nFür das Training müssen alle Geräte Zugang \nzu einem Netzwerk haben. \n \nAlle, auch der Trainer, öffnen kurz das Feld \nTeilnehmer/in. Der Trainer zeigt den \nTeilnehmern seine IP-Adresse. Die \nTeilnehmer geben diese ins Feld „Verbinden \nmit“ ein und Speichern diese. \n \n";
        titles[3] = "Teamtraining (2/2)";
        texts[3] = "Danach kann der Trainer zurückgehen und sich als Trainer anmelden. Automatisch verbinden sich alle Geräte untereinander. \n\n Nachdem das Training gestartet ist, kann der Trainer die Alarmmaske ausfüllen und die einzelnen Meldungen abschicken. Zeitgleich laufen die Alarme auf den vernetzten Geräten ein. ";
        titles[4] = "Einzeltraining";
        texts[4] = "Im Menü Simulation kannst Du ein Einzeltraining starten. \n\n Vorbereitete Szenarien werden automatisch vom Server auf Dein Gerät geschickt. Du selbst kannst auch Szenarien anlegen und Diese abspeichern. Somit kannst Du auch ein Einzeltraining für Dich selbst oder andere vorbereiten. ";
        titles[5] = "Partnertraining";
        texts[5] = "Im Menü Simulation kannst Du ein Partnertraining starten. \n\n Du selbst kannst Szenarien anlegen und Diese abspeichern. \n\n Das Partnertraining erlaubt dir, während einer Übung, auf einem Gerät zwischen dem Trainermodus und dem Übungsmodus zu wechseln. \n\n Ganz bequem um ein intensives 1 zu 1 Training zu absolvieren.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string[] getTitles()
    {
        return this.titles;
    }

    public string[] getTexts()
    {
        return this.texts;
    }
}

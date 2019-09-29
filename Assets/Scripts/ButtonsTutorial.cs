using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsTutorial : MonoBehaviour
{

    public GameObject info;

    public MessageView messageView;

    public Text InfoText;

    // Start is called before the first frame update
    void Start()
    {
        info.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayClicked()
    {
        InfoText.text = "<b>Erste Meldung</b>" + 
                        "\n" +
                        "In dieser Zeile läuft der erste Melder auf. Angezeigt werden die Meldergruppe und die Meldernummer. " +
                        "Zu der Meldergruppe gibt es eine Laufkarte. In dieser sind die jeweiligen Melder eingetragen. " +
                        "Zusätzlich erscheint ein Hinweistext zu dem Melder/Alarm." +
                        "\n \n" +
                        "<b>Letzte Meldung</b>" +
                        "\n" +
                        "In dieser Zeile läuft der zeitlich zuletzt aufgelaufene Melder ein. " +
                        "Dieser wird mit Meldergruppe und Meldernummer angezeigt." +
                        "\n";
        info.SetActive(true);
        
    }

    public void upOrDownClicked()
    {
        InfoText.text = "<b>Weitere Meldungen</b>" +
                        "\n \n" +
                        "Blättern - Laufen mehr als zwei Meldungen ein, können mit den Knöpfen die weiteren Meldungen angezeigt werden. " +
                        "Diese erscheinen dann in der ersten Zeile in der Reihenfolge, in der sie aufgelaufen sind. " +
                        "Der Pfeil nach oben – vorwärtsblättern, Pfeil nach unten rückwärtsblättern." + 
                        "\n \n" +
                        "Beendet man die Bedienung, springt die Anlage nach wenigen Sekunden in den Zustand erste Meldung, letzte Meldung zurück." +
                        "\n";
        info.SetActive(true);
    }

    public void anzeigeebeneClicked()
    {
        InfoText.text = "<b>Anzeigeebene / Historie</b>" +
                        "\n \n" +
                        "Durch betätigen dieses Stellteils kann zwischen den Anzeigeebenen Alarmzustand, Störungsmeldezustand und Abschaltzustand umgeschaltet werden." +
                        "\n" +
                        "Durch einmaliges Betätigen des Stellteils von mehr als 5 Sekunden wird am FAT (Feuerwehr Anzeige Tableau) die Historie der Alarmmeldungen angezeigt."+
                        "\n";
        info.SetActive(true);
    }

    public void summerClicked()
    {
        InfoText.text = "<b>Summer ab</b>" +
                        "\n" + "\n" +
                        "Durch Betätigen dieses Stellteiles wird der akustische Signalgeber des FAT abgestellt." +
                        "Mit dem Akustiksignal wird signalisiert, dass ein Brandmeldezustand vom FAT empfangen und noch nicht quittiert wurde. " +
                        "Die akustische Anzeige muss bei der Alarmmeldung aus einer weiteren Meldergruppe wiederkehren. +" +
                        "\n \n \n" +
                        "<b>Summer Ab / Test</b>" +
                        "\n \n" +
                        "Durch Betätigen des Stellteils von mehr als 5 Sekunden wird am FAT (Feuerwehr Anzeige Tableau) eine Anzeigetest durchgeführt. " +
                        "Beim Test werden alle Anzeigemittel und der akustische Signalgeber für mindestens die Betätigungsdauer aktiviert."+
                        "\n";
        info.SetActive(true);
    }

    public void LEDsBMAClicked()
    {
        InfoText.text = "<b>Betrieb</b>" +
                        "\n" +
                        "Betriebsbereiter Zustand des FAT wird angezeigt." +
                        "\n" + "\n" +
                        
                        "<b>Alarm</b>" +
                        "\n" +
                        "Es wird angezeigt, dass sich die Brandmeldezentrale im Alarmzustand befindet." +
                        "\n" + "\n" +
                        
                        "<b>Störung</b>" +
                        "\n" +
                        "Die Brandmeldezentrale befindet sich im Störungszustand." +
                        "\n" + "\n" +
                        
                        "<b>Abschaltung</b>" +
                        "\n" +
                        "Es wird angezeigt, dass sich Meldergruppen und / oder Melder im Abschaltzustand befinden." +
                        "\n";
        info.SetActive(true);
    }

    public void bedienfeldInBetriebClicked()
    {
        InfoText.text = "<b>Bedienfeld in Betrieb</b>" +
                        "\n \n" +            
                        "Das Feuerwehrbedienfeld ist betriebsbereit.";
        info.SetActive(true);
    }

    public void loeschanlageAusgeloestClicked()
    {
        InfoText.text = "<b>Löschanlage ausgelöst</b>" +
                        "\n \n" +
                        "Eine Löschanlage hat ausgelöst. " +
                        "\n" +
                        "Die Anzeige leuchtet, bis die Alarmrückstellung der ausgelösten Löschanlage erfolgt ist.";
            info.SetActive(true);
    }

    public void UEAbClicked()
    {
        InfoText.text = "<b>Übertragungseinheit ab</b>" +
                        "\n \n" +
                        "Die Ansteuereinrichtung für die Übertragungseinheit kann mit dem Knopf abgeschaltet werden." +
                        "Leuchtet der Knopf, ist die Übertragungseinheit abgeschaltet. Durch nochmaliges Betätigen kann die Abschaltung zurückgenommen werden."+
                        "\n";
        info.SetActive(true);
    }

    public void akustikAbClicked()
    {
        InfoText.text = "<b>Akustische Signale ab</b>" +
                         "\n \n" +
                        "Mit dem Knopf werden die Alarmierungseinrichtungen (Räumungsalarm) der BMA abgeschaltet. " +
                        "Leuchtet der Knopf, ist die Alarmierungseinrichtung (der Räumungsalarm) abgeschaltet. " +
                        "Durch nochmaliges Betätigen kann die Abschaltung zurückgenommen werden." +
                        "\n";
        info.SetActive(true);
    }

    public void BFSteuerungAbClicked()
    {
        InfoText.text = "<b>Brandfall-Steuerung ab</b>" +
                        "\n \n" +
                        "Mit dem Knopf werden alle Ansteuereinrichtungen der BMZ für Steuereinrichtungen abgeschaltet, " +
                        "die zur automatischen Auslösung von Brandschutz- und Betriebseinrichtungen im Gebäude im Brandmeldezustand der BMA vorgesehen sind. " +
                        "\n" +
                        "Die Abschaltung darf nur möglich sein, wenn sich die BMA nicht im Brandmeldezustand befindet. Im abgeschalteten Zustand leuchtet der Knopf. " +
                        "Durch nochmaliges Betätigen kann die Abschaltung zurückgenommen werden." +
                        "\n";
        info.SetActive(true);
    }

    public void BMZRueckclicked()
    {
        InfoText.text = "<b>BMZ Rückstellen</b>" +
                        "\n \n" +
                        "Mit rotem Dauerlicht wird angezeigt, dass sich die BMZ im Brandmeldezustand befindet oder befand. " +
                        "Die Anzeige leuchtet nach dem Einschalten mindestens 15 Minuten unbeeinflussbar vom Betreiber. " +
                        "Sie erlischt nach dieser Zeit, wenn BMZ und ÜE wieder zurückgestellt wurden. Sie erlischt vor dieser Zeit, mit Betätigung des Knopfes." +
                        "\n" +
                        "Mit dieser Betätigung wird die BMA vom Brandmeldezustand in den betriebszustand zurückgestellt." +
                        "\n";
        info.SetActive(true);
    }

    public void UEausgeloestClicked()
    {
        InfoText.text = "<b>Übertragungseinheit ausgelöst</b>" +
                        "\n \n" +
                        "Die Übertragungseinrichtung der Brandmeldungen ist durch die BMZ ausgelöst." +
                        "\n";
        info.SetActive(true);
    }

    public void UEpruefenClicked()
    {
        InfoText.text = "<b>Übertragungseinheit prüfen</b>" +
                        "\n \n" +
                        "Mit dem Knopf wird die Ansteuereinrichtung für die Übertragungseinheit der BMZ angesteuert, ohne dass die BMA in den Brandmeldezustand übergeht. " +
                        "Hiermit wird die Übertragungseinrichtung geprüft. Insbesondere wird die Brandfallsteuerung nicht ausgelöst. Der Räumungsalarm bleibt still." +
                        "\n";
        info.SetActive(true);
    }

    public void backToTutorial()
    {
        info.SetActive(false);
    }
}

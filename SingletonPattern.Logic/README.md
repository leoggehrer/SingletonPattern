# Umsetzung vom Singleton-Pattern mit C#

Das **Singleton-Pattern** definiert das Lösungsmuster unabhängig von der verwendeten Programmiersprache. Die einzige Vorraussetzung ist, dass die Programmiersprache das **objektorientierte** Paradigma unterstütz.

In diesem Abschnitt soll gezeigt werden, wie mit **C#** das Muster in unterschiedlichen Varianten umgesetzt werden kann.

## Umsetzung mit einem Lock-Objekt

Die Umsetzung mit einem **Lock-Objekt** erfordert die Bereitstellung eines speziellen Objektes (`_lock-Object`) für die Erstellung der Instanz. Dieses Objekt stellt sicher, dass in einer **Multitasking** Umgebung eine einzige Instanz instanziiert wird.

Den Quellcode für  die "*Umsetztung mit einem Lock-Objekt*" finden Sie auf GitHub unter folgendem [Link](https://github.com/leoggehrer/ObserverPattern/tree/main/SingletonPattern.Logic/WithLock).

**Funktionsweise:**

1. **Erste Prüfung (`if (_instance == null)`)** :
   * Verhindert, dass jeder Zugriff auf die Singleton-Instanz einen Lock benötigt, was die Leistung verbessert.
2. **Locking (`lock (_lock)`)** :
   * Wenn die Instanz noch nicht existiert, wird ein Lock verwendet, um sicherzustellen, dass nur ein Thread die Instanz erstellen kann.
3. **Zweite Prüfung im Lock-Bereich** :
   * Verhindert, dass mehrere Threads gleichzeitig die Instanz erstellen, falls einer während des Locks bereits die Instanz erstellt hat.

## Umsetzung mit einem Lazy-Objekt

Eine bevorzugte Implementierung ist die Verwendung mit einer **Lazy-Instanz**. Bei dieser Art wird der generische Typ `Lazy<>` verwendet. Die Verwendung dieses Types bietet eine thread-sicher Implementierung des Singleton-Patterns. Den Quellcode für  die "*Umsetztung mit einem Lazy-Objekt*" finden Sie auf GitHub unter folgendem [Link](https://github.com/leoggehrer/SingletonPattern/tree/main/SingletonPattern.Logic/WithLazy).

**Erklärungen:**

1. **`Lazy<T>`**: Wird verwendet, um eine verzögerte Initialisierung der Singleton-Instanz zu gewährleisten. Dies bedeutet, dass die Instanz nur erstellt wird, wenn sie das erste Mal benötigt wird.
2. **`readonly`**: Stellt sicher, dass die _instance-Variable nur einmal gesetzt werden kann.
3. **Thread-Sicherheit**: Die Implementierung von Lazy `<T>` sorgt dafür, dass die Initialisierung der Instanz thread-sicher ist.

## Umsetzung mit Eager-Initialization

Bei dieser Variante erfolgt die Initialisierung des Objektes bevor ein Zugriff auf die Klasse erfolgt. Somit ist auch diese Variante in einer **Multitasking** Umgebung sehr stabil. Den Quellcode für  die "*Umsetztung mit einem Lazy-Objekt*" finden Sie auf GitHub unter folgendem [Link](https://github.com/leoggehrer/SingletonPattern/tree/main/SingletonPattern.Logic/WithEager).

## Umsetzung mit Static-Members

Bei diese Variante wird das Konzept der statischen Klasse in C# verwendet. Dabei handelt es sich um eine spezielle Klassendefinition, die ausschließlich statische Mitglieder enthält und nicht insstanziiert werden kann. Den Quellcode für  die "*Umsetztung mit Static-Members*" finden Sie auf GitHub unter folgendem [Link](https://github.com/leoggehrer/SingletonPattern/tree/main/SingletonPattern.Logic/WithStatic).

## Gegenüberstellung der unterschiedlichen Varianten

Hier ist eine tabellarische Gegenüberstellung der unterschiedlichen Varianten:

| **Variante**                                  | **Beschreibung**                                                                                                                          | **Thread-Sicherheit**    | **Lazy-Loading** | **Komplexität** | **Empfohlene Anwendung**                                                    |
| --------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------ | ---------------------- | ---------------------- | --------------------------------------------------------------------------------- |
| **Eager Initialization**                      | Die Instanz wird direkt beim Laden der Klasse erstellt. Einfach umzusetzen.                                                                     | Thread-sicher                  | Nein                   | Einfach                | Wenn die Instanz immer benötigt wird und sofort verfügbar sein muss.            |
| **Lazy`<T>`**                               | Verwaltet die verzögerte (Lazy-)Initialisierung und Thread-Sicherheit automatisch. Sehr moderne und saubere Lösung.                           | Thread-sicher                  | Ja                     | Einfach                | Empfohlen für die meisten modernen Anwendungen.                                  |
| **Double-Check Locking**                      | Nutzt ein `lock`-Objekt und prüft zweimal, ob die Instanz bereits erstellt wurde, um unnötige Sperren zu vermeiden.                         | Thread-sicher                  | Ja                     | Mittel                 | Wenn man mehr Kontrolle über die Synchronisierung benötigt.                     |
| **Einfaches Singleton (nicht thread-sicher)** | Eine einfache statische Instanz ohne Thread-Sicherheit. Kann zu Problemen führen, wenn mehrere Threads gleichzeitig auf die Instanz zugreifen. | Nicht thread-sicher            | Nein                   | Einfach                | Nur in Single-Thread-Umgebungen oder wenn Thread-Sicherheit nicht benötigt wird. |
| **Vollständig statischer Typ**               | Die Klasse enthält nur statische Mitglieder und Methoden. Kein Konstruktor erforderlich.                                                       | Thread-sicher (je nach Design) | Nein                   | Einfach                | Für Klassen, die rein statische Methoden bereitstellen sollen.                   |

### Fazit

* Verwenden Sie **`Lazy<T>`**, wenn Sie eine moderne und einfache Lösung mit Thread-Sicherheit und Lazy-Loading benötigen.
* **Eager Initialization** ist ideal, wenn die Instanz immer benötigt wird und keine Lazy-Initialisierung erforderlich ist.
* **Double-Check Locking** wird verwendet, wenn präzise Kontrolle über die Synchronisation nötig ist.
* Vermeiden Sie das einfache, nicht thread-sichere Singleton, außer in Single-Thread-Umgebungen.

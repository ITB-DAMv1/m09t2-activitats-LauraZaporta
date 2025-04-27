## Exercicis teòrics:

### 1. Llibreria System.Diagnostics

#### _UTILITAT GENERAL:_ 
Permet obtenir informació detallada del comportament d’una aplicació.

#### _MÈTODES RELLEVANTS:_
- Process.Start(): Inicia un programa
- Process.GetProcesses(): Retorna la informació de tots els processos actuals del sistema
- Process.GetProcessByName(): Retorna el procés o llista de processos amb X nom
- Process.GetProcessById(): Retorna el procés amb una id concreta
- ProcessInstance.StartInfo...: Permet configurar informació abans de començar un procés
- Process.Kill(): Acaba amb un procés
- Debug.WriteLine(): Escriu un missatge al monitor de depuració
- Debug.Assert(): Llança error si la condició dintre la funció és falsa
- ...

#### _PROPIETATS RELLEVANTS._
- Process
- Debug
- Trace
- EventLog

-------------

### 4. Classe Thread:

#### _MÈTODES DESTACATS:_
- ThreadInstnce.Join(): Dóna prioritat al fil indicat per sobre del flux del programa principal.
- ThreadInstance.Start(): Comença el flux d'un fil.
- Thread.Sleep(): Similar a delay, fa que un fil es vegi retrassat per un temps determinat.
- Thread.CurrentThread (Propietat): Retorna el fil que està en execució al moment.
- Thread.GetCurrentProcessorId(): Retorna l'identificador utilitzat per veure en quin processador s'estàa executant el fil del moment.

#### _QUADRE COMPARATIU THREAD-TASK:_

| Aspecte | **Thread** | **Task** |
|:---|:---|:---|
| **Definició** | Fil físic d'execució del sistema operatiu. | Unitat de treball d'execució asíncrona. |
| **Creació** | Manual | Més automàtic: pot començar amb `Task.Run()` o `Task.Start()`. |
| **Gestió de recursos** | Més pesat (cada `Thread` consumeix més recursos). | Més lleuger: es basen en el `ThreadPool` i reutilitzen fils. |
| **Sincronització** | Cal controlar-la manualment (ex: `Join()`, `Start()`). | Proporciona eines més senzilles (ex: `await`, `ContinueWith`). |
| **Control** | + control directe (prioritat, interrupció). | Controla automàticament planificació i excepcions. |
| **Ús habitual** | En manipulació de fils a baix nivell. | Situacions asíncrones i paral·lelisme d'alt nivell. |
| **Exemples** | ```new Thread(() => { /* funcionalitat */ }).Start();``` | ```Task.Run(() => { /* funcionalitat */ });``` |

-------------

### 5. Classe Thread:

#### _Per què s'imprimeixen de certa manera (Sense sleeps ni joins)?_ 
Perquè l'ordre d'execució dels threads el determina el sistema que gestiona la prioritat de cada procés (si el programa no especifica res). Aquesta prioritat és definida per la disponibilitat de recursos del hardware.

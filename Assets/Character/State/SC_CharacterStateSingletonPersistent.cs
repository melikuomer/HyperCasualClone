public sealed class SC_CharacterStateSingletonPersistent {
    private SC_CharacterStateSingletonPersistent() {}
    private static SC_CharacterStateSingletonPersistent instance = null;
    public static SC_CharacterStateSingletonPersistent Instance {
        get {
            if (instance == null) {
                instance = new SC_CharacterStateSingletonPersistent();
            }
            return instance;
        }
    }


    
}
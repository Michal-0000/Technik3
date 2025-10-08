def wyrazy(zaw):
    return len(zaw.split())

def zdania(zaw):
    return zaw.count(".")

def akapity(zaw):
    return zaw.count("\n\n") + 1


def main():
    plik = input("Podaj nazwę pliku")
    try:
        with open(plik, "+rt") as file:
            zaw = file.read()
            
            print(f"Ilosc wyrazow: {wyrazy(zaw)}")
            print(f"Ilosc zdań: {zdania(zaw)}")
            print(f"Ilosc akapitó: {akapity(zaw)}")
            
            
    except FileNotFoundError:
        print("Nie znaleziono pliku")
    except Exception as e:
        print(f"blad: {e}")
    
    
if __name__ == "__main__":
    main()
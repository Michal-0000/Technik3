import random as rd

def generator(nazwa, tryb):
    try:
        with open(nazwa, tryb) as file: file.write( "".join([str(rd.randint(1, 100))+" "+"".join([chr(rd.randint(97, 122)) for _ in range(6,14)])+" "+str(round(rd.uniform(0,100), 2))+"\n" for _ in range(1000)]))
    except Exception as ex:
        print(f"Wystąpil blad: {ex}")
    finally: 
        print("Zakonczono zapis")
    
def wczytywanie(nazwa, tryb):
    with open(nazwa, tryb) as file: 
        linie = file.read().split()
    #zadanie2(linie)
    #zadanie3(linie)
    zadanie4(linie)
        
                
def zadanie2(linie):
    for linia in linie[0::3]:
            if czyPierwsza(int(linia)):
                print(linia)
                
def zadanie3(linie):
    for linia in linie[1::3]:
        czyPal = True
        for i in range(len(linia) // 2):
            if linia[i] != linia[len(linia) -i-1]:
                czyPal = False
                break
        if czyPal:
            print(linia)

#suma cyfr
def zadanie4(linie):
    for linia in linie[2::3]:
        liczby = linia.split(".")
        if sum(int(l) for l in liczby[0]) == sum(int(l) for l in liczby[1]):
            print(linia)
        
             
                

def czyPierwsza(liczba):
    if liczba < 2:
        return False
    if liczba == 2:
        return True
    if liczba % 2 == 0:
        return False
    for i in range(3, int(liczba**0.5)+1,2):
        if liczba % i == 0:
            return False
    return True
    
        
        
        
            
    
def main():
    #generator("slowa.txt", "+wt")
    wczytywanie("slowa.txt", "+rt")
    
if __name__ == "__main__":
    main()
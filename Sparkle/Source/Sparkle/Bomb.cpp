// Fill out your copyright notice in the Description page of Project Settings.


#include "Bomb.h"

// Sets default values
ABomb::ABomb()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	rulesDictionary.Add(TEXT("A"), TEXT("RED Wire"));
	rulesDictionary.Add(TEXT("B"), TEXT("BLUE Wire"));
	rulesDictionary.Add(TEXT("C"), TEXT("GREEN Wire"));
	rulesDictionary.Add(TEXT("D"), TEXT("YELLOW Wire"));
	rulesDictionary.Add(TEXT("E"), TEXT("WHITE Wire"));
	rulesDictionary.Add(TEXT("F"), TEXT("GOLD Wire"));
	rulesDictionary.Add(TEXT("G"), TEXT("FAKE Wire"));
	rulesDictionary.Add(TEXT("H"), TEXT("FAKE Wire"));
	rulesDictionary.Add(TEXT("I"), TEXT("FAKE Wire"));
	rulesDictionary.Add(TEXT("J"), TEXT("FAKE Wire"));


	cutDictionary.Add(1, TEXT("3 wires"));
	cutDictionary.Add(2, TEXT("2 wires"));
	cutDictionary.Add(3, TEXT("1 wire"));
	cutDictionary.Add(4, TEXT("5 wires"));
	cutDictionary.Add(5, TEXT("4 wires"));
	cutDictionary.Add(6, TEXT("3 wires"));
	cutDictionary.Add(7, TEXT("2 wires"));
	cutDictionary.Add(8, TEXT("2 wires"));
	cutDictionary.Add(9, TEXT("1 wires"));
	cutDictionary.Add(0, TEXT("4 wires"));


}

// Called when the game starts or when spawned
void ABomb::BeginPlay()
{
	Super::BeginPlay();
	//creates a serial number, first character being a letter from the rulesdictionary and the second character being a number from cutDictionary
	//first, get a random letter from the rulesDictionary
	int32 randomLetter = FMath::RandRange(0, rulesDictionary.Num() - 1);
    FString letter;
	rulesDictionary.GenerateKeyArray(rulesArray);
	letter = rulesArray[randomLetter];
	//then get a random number from the cutDictionary
	int32 randomNum = FMath::RandRange(0, cutDictionary.Num() - 1);
	int32 num;
	cutDictionary.GenerateKeyArray(cutArray);
	num = cutArray[randomNum];
	if (!rulesDictionary.Find(letter)->Contains("FAKE"))
	{
		wireArray.Add(rulesDictionary.FindRef(letter));
		wireCutArray.Add(cutDictionary.FindRef(num));

	}
	//create the serial number by combining the letter and number
	serialNumber = letter + FString::FromInt(num);
	//repeats this process 5 times to create a 5 digit serial number
	for (int i = 0; i < 5; i++) {
		randomLetter = FMath::RandRange(0, rulesDictionary.Num() - 1);
		letter = rulesArray[randomLetter];
		randomNum = FMath::RandRange(0, cutDictionary.Num() - 1);
		num = cutArray[randomNum];
		serialNumber += letter + FString::FromInt(num);
		if (!rulesDictionary.Find(letter)->Contains("FAKE"))
		{
			wireArray.Add(rulesDictionary.FindRef(letter));
			wireCutArray.Add(cutDictionary.FindRef(num));

		}
	}

	UE_LOG(LogTemp, Warning, TEXT("Serial Number: %s"), *serialNumber);

	//works backwards from the serial number in order to print the correct instructions
	//if a character, it's a colour and if it's a number, it's the number of wires to cut

	//first, get the last character of the serial number
	TCHAR lastChar = serialNumber[serialNumber.Len() - 1];
	//if it's a number, print the number of wires to cut
	if (lastChar >= 48 && lastChar <= 57) {
		UE_LOG(LogTemp, Warning, TEXT("Cut %s wires"), *cutDictionary[lastChar - 48]);
	}
	//if it's a character, print the colour of the wire to cut
	else {
		UE_LOG(LogTemp, Warning, TEXT("Cut the %s wire"), *rulesDictionary[letter]);
	}
	//repeat this process for the rest of the serial number
	for (int i = serialNumber.Len() - 2; i >= 0; i--) {
		TCHAR character = serialNumber[i];
		if (character >= 48 && character <= 57) {
			UE_LOG(LogTemp, Warning, TEXT("Cut %s wires"), *cutDictionary[character - 48]);
		}
		else {
			//convert the character to a string and print the colour of the wire to cut
			FString fletter = FString(1, &character);
			UE_LOG(LogTemp, Warning, TEXT("Cut the %s wire"), *rulesDictionary[fletter]);

		}
	}
	

}

// Called every frame
void ABomb::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}


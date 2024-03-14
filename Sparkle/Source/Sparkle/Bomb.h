// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "Bomb.generated.h"

UCLASS()
class SPARKLE_API ABomb : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	ABomb();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;


	TMap<FString, FString> rulesDictionary;//what wires to cut
	TMap<int, int> cutDictionary;// how many wires to cut
	//array for values of rules and number of wires to cut for easy access
	TArray<FString> rulesArray;
	TArray<int> cutArray;

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Bomb")
		int32 bombTimer;

        UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Bomb")
		int32 cutWire;

		//array of wires
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Bomb")
		TArray<FString> wireArray;
	//array of how many wires 
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Bomb")
		TArray<int> wireCutArray;



	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Bomb")
		FString serialNumber;

};

// Fill out your copyright notice in the Description page of Project Settings.


#include "Bomb.h"

// Sets default values
ABomb::ABomb()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
	FruitMap.Add(5, TEXT("Banana"));
	FruitMap.Add(3, TEXT("FUCk you"));
	rulesArray.Add(TEXT("A"), TEXT("RED Wire"));
}

// Called when the game starts or when spawned
void ABomb::BeginPlay()
{
	Super::BeginPlay();

    for (auto& Elem : FruitMap)
    {
		UE_LOG(LogTemp, Warning, TEXT("%s"), *Elem.Value);
    }
	
}

// Called every frame
void ABomb::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}


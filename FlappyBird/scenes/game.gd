extends Node2D

var pipes_prefab = preload("res://pipes.tscn")
var last_time_spawn = 0
@onready var bird = $bird
@onready var label = $Label

var score = 0

func _ready():
	last_time_spawn = Time.get_ticks_msec()

func _process(delta):
	if Time.get_ticks_msec() - last_time_spawn > 2000:
		last_time_spawn = Time.get_ticks_msec()
		var pipe_instance:Node2D = pipes_prefab.instantiate()
		pipe_instance.position.x = 170
		pipe_instance.position.y = randi_range(-355, -155)
		
		pipe_instance.bird_hit.connect(_pipe_hit)
		pipe_instance.bird_score.connect(_score)
		
		add_child(pipe_instance)

func _pipe_hit():
	get_tree().change_scene_to_file("res://scenes/dead.tscn")
	
func _score():
	score += 1
	label.text = str(score)


func _on_ground_body_entered(body):
	get_tree().change_scene_to_file("res://scenes/dead.tscn")

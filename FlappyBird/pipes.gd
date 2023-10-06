extends Node2D

signal bird_hit
signal bird_score
	
func _physics_process(delta):
	position.x -= delta * 100
	
	if position.x < -170:
		queue_free()


func _on_pipe_entered(body):
	bird_hit.emit()


func _on_score_area_exit(body):
	bird_score.emit()

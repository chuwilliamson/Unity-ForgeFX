using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AttachmentBehaviour : MonoBehaviour
{
   public static UnityEvent<LimbBehaviour> AttachmentEvent;

   private void Awake()
   {
      AttachmentEvent = new UnityEvent<LimbBehaviour>();
   }

   public void OnTriggerEnter(Collider other)
   {
      var lb = other.GetComponent<LimbBehaviour>();
      if (lb == null || !lb.CompareTag($"limb"))
         return;
      
      Attach(lb);
   }

   
   
   public void OnTriggerExit(Collider other)
   {
      var lb = other.GetComponent<LimbBehaviour>();
      if (lb == null || !lb.CompareTag($"limb"))
         return;
      
      Detach(lb);
   }
   public void Detach(LimbBehaviour limbBehaviour)
   {
      if (!limbBehaviour.Attached) return;
      var limbBehaviourTransform = limbBehaviour.transform;
      limbBehaviour.PreviousParentTransform = limbBehaviourTransform.parent;
      limbBehaviourTransform.SetParent(null);
      limbBehaviour.Attached = false;
      AttachmentEvent.Invoke(limbBehaviour);
   }
   public void Attach(LimbBehaviour limbBehaviour)
   {
      if (limbBehaviour.Attached) return;
      limbBehaviour.GetComponent<DragObjectBehaviour>().StopDragging();
      var limbBehaviourTransform = limbBehaviour.transform;
      limbBehaviourTransform.SetParent(limbBehaviour.PreviousParentTransform);
      limbBehaviourTransform.position = transform.position;
      limbBehaviour.Attached = true;
      AttachmentEvent.Invoke(limbBehaviour);
      
   }

}
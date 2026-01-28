"use client";

import { motion, useAnimation, useInView } from "framer-motion";
import { PropsWithChildren, useEffect, useRef } from "react";

type SectionWrapperProps = PropsWithChildren<{
  id?: string;
  className?: string;
  delay?: number;
}>;

export default function SectionWrapper({
  id,
  className = "",
  delay = 0,
  children,
}: SectionWrapperProps) {
  const ref = useRef<HTMLDivElement | null>(null);
  const controls = useAnimation();
  const inView = useInView(ref, {
    margin: "0px 0px -30% 0px",
    once: true,
  });

  useEffect(() => {
    if (inView) {
      controls.start("visible");
    }
  }, [inView, controls]);

  return (
    <motion.section
      id={id}
      ref={ref}
      initial="hidden"
      animate={controls}
      variants={{
        hidden: { opacity: 0, y: 24 },
        visible: {
          opacity: 1,
          y: 0,
          transition: { duration: 0.7, ease: "easeOut", delay },
        },
      }}
      className={`section-padding ${className}`}
    >
      {children}
    </motion.section>
  );
}

